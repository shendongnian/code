    var results = Teachers
                  .Where(t => t.IsActive == true)
                  .Select(t => 
                  {
                      TeacherID  = t.TeacherID,
                      FirstName = t.FirstName,
                      LastName = t.LastName,
                      Title = t.Title,
                      Grade = t.Grade,
                      Count = t.Students.Count,					
                  });	
     results.ToList().Dump(); 
