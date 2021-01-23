     var db = new DBHelper();
    
     ParameterExpression entity = 
        Expression.Parameter(typeof(HighSchoolServicesDataAccess.Faculty), 
            "entity");
     Expression<Func<HighSchoolServicesDataAccess.Faculty, bool>> filterentity = 
        Expression.Lambda<Func<HighSchoolServicesDataAccess.Faculty, bool>>(
        Expression.Equal(
          Expression.Property(entity, "HighSchoolID"), 
            Expression.Constant(90, typeof(int))), entity);
     // not at all needed...
     //Func<HighSchoolServicesDataAccess.Faculty, bool> predicate =
     //   (Func<HighSchoolServicesDataAccess.Faculty, bool>)filterentity.Compile();
    
     var res = db.DBContext.Faculties.Where(filterentity);
     dataGridView2.DataSource = res.ToList();
