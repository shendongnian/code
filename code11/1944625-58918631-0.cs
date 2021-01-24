csharp
            var query = collection.Aggregate()
                                  .Project(s => new
                                  {
                                      s.Id,
                                      s.Name,
                                      s.CoursesTaken,
                                      lastCourse = s.CoursesTaken.Last()
                                  })
                                  .Match(x => x.lastCourse == "avacados")
                                  .Project(x => new Student
                                  {
                                      Id = x.Id,
                                      Name = x.Name,
                                      CoursesTaken = x.CoursesTaken
                                  });
here's a full test program
