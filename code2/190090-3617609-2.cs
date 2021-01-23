    Students students = new Students();
    students.AddStudent(new Student { Age = 20, Name = "Stud1", City = "City1" });
    students.AddStudent(new Student { Age = 46, Name = "Stud2", City = "City2" });
    students.AddStudent(new Student { Age = 32, Name = "Stud3", City = "City3" });
    students.AddStudent(new Student { Age = 34, Name = "Stud4", City = "city4" });
    foreach (int studentAge in students.EnumerateBy(StudentProperty.Age))
    {
        Console.WriteLine(studentAge);
    }
    foreach (string studentName in students.EnumerateBy(StudentProperty.Name))
    {
        Console.WriteLine(studentName);
    }
    foreach (string studentCity in students.EnumerateBy(StudentProperty.City))
    {
        Console.WriteLine(studentCity);
    }
    // ...
    public class Students
    {
        private List<Student> _students = new List<Student>();
        
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public IEnumerable<T> EnumerateBy<T>(StudentProperty<T> property)
        {
            return _students.Select(property.Selector);
        }
    }
    public static class StudentProperty
    {
        public static readonly StudentProperty<int> Age =
            new StudentProperty<int>(s => s.Age);
        public static readonly StudentProperty<string> Name =
            new StudentProperty<string>(s => s.Name);
        public static readonly StudentProperty<string> City =
            new StudentProperty<string>(s => s.City);
    }
    public sealed class StudentProperty<T>
    {
        internal Func<Student, T> Selector { get; private set; }
        internal StudentProperty(Func<Student, T> selector)
        {
            Selector = selector;
        }
    }
