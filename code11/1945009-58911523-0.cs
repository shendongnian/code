    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    
    public class StudentsInformation
    {
        public string SchoolName { get; set; }
        public List<Student> Student { get; set; }
    }
