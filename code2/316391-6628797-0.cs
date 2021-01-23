    var teachers = 
       (from t in Teachers
        join s in Students on t.TeacherID equals s.TeacherID 
        into results
        where t.IsActive == true 
        from r in results.DefaultIfEmpty()                                       
        group r by new { r.TeacherID, r.Teacher.FirstName, r.Teacher.LastName, r.Teacher.Title, r.Teacher.Grade} into g
        select new  { TeacherID = g.Key.TeacherID,FirstName = g.Key.FirstName, LastName = g.Key.LastName, Title=g.Key.Title, Grade = g.Key.Grade}                
       );
