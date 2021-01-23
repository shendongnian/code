        public static List<Student> GetStudents(int gradeId)
        {
            using (var context = new Entities())
            {
                List<Student> myList = (from s in dbContext.Student 
    join si in dbContext.StudentInst on s.StudentID equals si.StudentInstanceID
    join g in dbContext.Grade on si.GradeInstanceID equals g.GradeID
    where g.GradeId = gradeId
    select s).ToList();
             return myList;
            }
        }
