    using (var ctx = new TrainingContext())
            {
                studentDo = ctx.Students
                    .Include("ClassRooms")
                    .Include("StudentDescriptions")
                    .Where(x=>x.StudentID==studentId)
                    .Select(x => new StudentDto
                            {
                                StudentId = x.StudentId,
                                StudentName = x.StudentName
                                StudentDescription = x.StudentDescription.Description
                            })
                    .SingleOrDefault();
            }
