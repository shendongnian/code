    public class Student
    {
        public string Name { get; }
        public int Grade { get; }
        public Student(string name, int grade)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (grade <= 0) throw new ArgumentException(nameof(grade));
            Grade = grade;
        }
    }
