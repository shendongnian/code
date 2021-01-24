 lang-cs
    public JsonResult GetData([DataSourceRequest] DataSourceRequest request)
    {
        using (GridEnt db = new GridEnt())
        {
            List<Cours> courses = db.Courses.ToList();
            List<Teacher> teachers = db.Teachers.ToList();
            var courseRecord = from t in teachers
                               join c in courses on t.Id equals c.Fk_Teacher into table1
                               from c in table1.ToList()
                               select new ViewModel
                               {
                                   teacher = t,
                                   cours = c,
                               };
            //return View(courseRecord);
            return Json(courseRecord.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
The "JsonRequestBehavior.AllowGet" part is only needed if you block GET request in your application.
