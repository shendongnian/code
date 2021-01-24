    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan Age => DateTime.Now - DateOfBirth;
    }
