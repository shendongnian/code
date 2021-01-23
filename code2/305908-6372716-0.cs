    using System.Xml;
    using System.Collections.Generic;
    
    namespace XmlExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
    
                students.Add(new Student { ID = 1, Name = "Ryan", Grade = 99 });
                students.Add(new Student { ID = 2, Name = "Ann", Grade = 84 });
                students.Add(new Student { ID = 3, Name = "Rebecca", Grade = 83 });
                students.Add(new Student { ID = 4, Name = "Jon", Grade = 26 });
    
                using (XmlWriter xml = XmlWriter.Create("ComputerScience1234.xml"))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("COSC1234");
    
                    foreach (Student s in students)
                    {
                        xml.WriteStartElement("Student");
    
                        xml.WriteElementString("ID", s.ID.ToString());
                        xml.WriteElementString("Name", s.Name);
                        xml.WriteElementString("Grade", s.Grade.ToString());
    
                        xml.WriteEndElement();
                    }
    
                    xml.WriteEndElement();
                    xml.WriteEndDocument();
    
                }
            }
        }
    }
