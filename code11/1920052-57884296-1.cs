     public ActionResult GetData([DataSourceRequest]DataSourceRequest request)
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
            DataSourceResult result = courseRecord.ToDataSourceResult(request);
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
