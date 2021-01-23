    var studentList = from student in context.Student
                      join marks in Context.Marks
                          on student.studentId equals marks.studentId
                      group by student
                      into g
                      select new
                      {
                          RollNo = g.Key.RollNo,
                          Name = g.Key.Name,
                          PhoneNo = g.Key.PhoneNo,
                          Marks = g.marks
                      };
                      
 
