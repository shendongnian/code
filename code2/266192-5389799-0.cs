    from g in db.Groups
    join e in db.Enrolments on g.CourseID equals e.GroupID
    join s in db.Students in e.StudentID equals s.StudentID
    join p in db.Progressions on s.StudentID equals p.StudentID  
    where p.IsReturning == 0  
    GROUP new {
       Group = g,
       Enrolment = e,
       Student = s,
       Progression = p
    } by g.GroupID into grouped 
    select new
    {
       GroupId = grouped.Key,
       Returning = grouped.Count()
    };
