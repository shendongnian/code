    [Serializable]
    public class Class
    {
        public Class()
        {
        }
    
        [XmlAttribute]
        public string ClassId{get;set;}
    
        [XmlAttribute]
        public Teacher Teacher{get;set;}
    
        [XmlArray("Students")]
        [XmlArrayItem("Student", Type=typeof(Student))]
        public List<Student> Students { get; } = new List<Student>();
    }
    
    
    [Serializable]
    public class Student 
    {
        public Student(string classId)
        {
            ClassId = classId;
        }
    
        public string ClassId{get;set;}
    
    
        [XmlAttribute]
        public string Name { get; set; } = "New Student";
    
        [XmlAttribute]
        public int Age { get; set; } = 10;
    
    }
