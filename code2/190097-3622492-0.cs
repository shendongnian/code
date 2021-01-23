    class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students();
            students.AddStudent(new Student { Age = 20, Name = "Stud1", City = "City1" });
            students.AddStudent(new Student { Age = 46, Name = "Stud2", City = "City2" });
            students.AddStudent(new Student { Age = 32, Name = "Stud3", City = "City3" });
            students.AddStudent(new Student { Age = 34, Name = "Stud4", City = "city4" });
            // in these two examples, you know exactly which property you want to iterate,
            // so call the corresponding iterator method directly.
            foreach (string studentCity in students.Cities())
            {
                Console.WriteLine(studentCity);
            }
            foreach (string studentName in students.Names())
            {
                Console.WriteLine(studentName);
            }
            
            // in these three cases, the DoSomethingWithPropertyValues method will not know which property is being iterated,
            // so it will have to use the PropertyValues method
            DoSomethingWithPropertyValues(students, eStudentProperty.Age);
            DoSomethingWithPropertyValues(students, eStudentProperty.Name);
            DoSomethingWithPropertyValues(students, eStudentProperty.City);
        }
        static void DoSomethingWithPropertyValues(Students students, eStudentProperty propertyToIterate)
        {
            // This method demonstrates use of the Students.PropertyValues method.
            // The property being iterated is determined by the propertyToIterate parameter,
            // therefore, this method cannot know which specific iterator method to call.
            // It will use the PropertyValues method instead.
            Console.WriteLine("Outputting values for the {0} property.", propertyToIterate);
            int index = 0;
            foreach (object value in students.PropertyValues(propertyToIterate))
            {
                Console.WriteLine("{0}: {1}", index++, value);
            }
        }
    }
    public class Students
    {
        private List<Student> m_Students = new List<Student>();
        public void AddStudent(Student i_Student)
        {
            m_Students.Add(i_Student);
        }
        public IEnumerable PropertyValues(eStudentProperty property)
        {
            switch (property)
            {
                case eStudentProperty.Name:
                    return this.Names();
                case eStudentProperty.City:
                    return this.Cities();
                case eStudentProperty.Age:
                    return this.Ages();
                default:
                    throw new ArgumentOutOfRangeException("property");
            }
        }
        public IEnumerable<string> Names()
        {
            foreach (var student in m_Students)
                yield return student.Name;
        }
        public IEnumerable<string> Cities()
        {
            foreach (var student in m_Students)
                yield return student.City;
        }
        public IEnumerable<int> Ages()
        {
            foreach (var student in m_Students)
                yield return student.Age;
        }
    }
    public enum eStudentProperty
    {
        Name,
        Age,
        City
    }
    public class Student
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
