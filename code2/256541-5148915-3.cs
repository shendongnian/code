    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        // etc
        public IEnumerable<Teacher> Teachers { get; }
    }
