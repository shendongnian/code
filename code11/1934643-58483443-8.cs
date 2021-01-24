    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan Age => DateTime.Now - DateOfBirth;
    }
