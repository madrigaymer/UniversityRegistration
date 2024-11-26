using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using university_registration_project_cris;

namespace university_registration_project_cris.Controllers
{
    public class T_STUDENTController : Controller
    {
        private DB_UNIVERSITY_REGISTRATIONEntities db = new DB_UNIVERSITY_REGISTRATIONEntities();

        // GET: T_STUDENT
        public ActionResult Index()
        {
            return View(db.T_STUDENT.ToList());
        }

        // GET: T_STUDENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_STUDENT t_STUDENT = db.T_STUDENT.Find(id);
            if (t_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(t_STUDENT);
        }

        // GET: T_STUDENT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_STUDENT/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "student_id,student_personal_id,student_name,student_last_name1,student_last_name2,student_date_of_birth,student_admission_date")] T_STUDENT t_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.T_STUDENT.Add(t_STUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_STUDENT);
        }

        // GET: T_STUDENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_STUDENT t_STUDENT = db.T_STUDENT.Find(id);
            if (t_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(t_STUDENT);
        }

        // POST: T_STUDENT/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "student_id,student_personal_id,student_name,student_last_name1,student_last_name2,student_date_of_birth,student_admission_date")] T_STUDENT t_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_STUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_STUDENT);
        }

        // GET: T_STUDENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_STUDENT t_STUDENT = db.T_STUDENT.Find(id);
            if (t_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(t_STUDENT);
        }

        // POST: T_STUDENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_STUDENT t_STUDENT = db.T_STUDENT.Find(id);
            db.T_STUDENT.Remove(t_STUDENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
