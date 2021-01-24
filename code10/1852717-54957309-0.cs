    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public Grade StudentGrade { get; set; }
    }
     
    …
    var data = context.Students.Include(x => x.Grade).Where(c => c.Id == studentId).SingleOrDefault();
