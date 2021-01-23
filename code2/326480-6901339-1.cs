     semesters.ToDictionary(semester => semester.Name, semester => 
                            semesters.SelectMany(sid => 
                                           CourseInstance.Get(sid.SemesterId))
                            .Select(c => new Course 
                            {Code = c.Course.Code, Name = c.Course.Name}).ToList())
