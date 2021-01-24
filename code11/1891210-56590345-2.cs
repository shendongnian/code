    public class Student
    {
        public string Name { get; }
        public int Grade { get; }
        public Student(string name, int grade)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Grade = (grade > 0) ? grade : throw new ArgumentException(nameof(grade));
        }
    }
