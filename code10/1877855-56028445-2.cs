    public class GenerateXml
    {
            public static void Create()
            {
                Class c = new Class();
                c.Teacher = new Teacher() {Name = "Mr. Henry"};
                var s = new Student() { Age = 14, Name = "Suzy", Teacher = c.Teacher };
                c.Students.Add(s);
                s = new Student() {Age = 13, Name = "Adam", Teacher = c.Teacher};
                c.Students.Add(s);
    
                var serializer = new XmlSerializer(c.GetType());
                XmlTextWriter writer = new XmlTextWriter("class.xml", Encoding.ASCII);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                serializer.Serialize(writer, c);
            }
    }
    
    [Serializable]
    public class Class
    {
        public Class()
        {
        }
        [XmlAttribute]
        public string ClassId { get; set; }
        [XmlElement]
        public Teacher Teacher { get; set; }
        [XmlArray("Students")]
        [XmlArrayItem("Student", Type = typeof(Student))]
        public List<Student> Students { get; } = new List<Student>();
    }
    [Serializable]
    public class Student
    {
        public Student()
        {
        }
        [XmlElement]
        public Teacher Teacher { get; set; }
        [XmlAttribute]
        public string ClassId { get; set; }
        [XmlAttribute]
        public string Name { get; set; } = "New Student";
        [XmlAttribute]
        public int Age { get; set; } = 10;
    }
    [Serializable]
    public class Teacher
    {
        public Teacher()
        {
        }
        [XmlAttribute]
        public string Name { get; set; } = "New Teacher";
        [XmlAttribute]
        public int Age { get; set; } = 30;
    }
