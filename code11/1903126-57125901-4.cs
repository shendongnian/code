       [XmlRoot("ArrayOfStudent")]
       public class ArrayOfStudent
       {
       [XmlElement("Student")]
       public IEnumerable<Student> Students { get; set; }
       }
       public class Student
       {
       [XmlElement("Id")]
       public int Id { get; set; }
       [XmlElement("Name")]
       public string Name { get; set; }
       }
