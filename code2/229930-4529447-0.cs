    List<Student> liStudent = new List<Student>
            {
                new Student("Mohan",1),
                new Student("Ravi",2)
            };
    public class Student
    {
        public Student(string name,int id)
        {
            Name=name;
            ID=id;
        }
        public string Name { get; set; }
        public int ID { get; set; }
    
    }
