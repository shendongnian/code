    var result = (from student in db.Students
                 join subject in db.Subjects on student.Subject equals subject.ID
                 join teacher in db.Teachers on subject.Teacher equals teacher.ID
                 where student.ID = 1
                 select new newModel()
                 {
                     studentList = student,
                     teacherList = teacher,
                     subejctList = subject
                 }).ToList();
