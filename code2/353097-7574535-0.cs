    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace ThrowAwayCSConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //Create an instance of the Person
                Person p = new Person { Name = "John Doe", Email = "jdoe@someisp.com" };
                p.PhoneNumbers.Add(new PhoneNumber { Type = "Home", Number = "999-555-1234" });
                p.PhoneNumbers.Add(new PhoneNumber { Type = "Work", Number = "999-555-9876" });
    
                StringBuilder output = new StringBuilder();
    
                XmlSerializer xSer = new XmlSerializer(typeof(Person));
    
                //serialize it to xml
                using (StringWriter wrt = new StringWriter(output))
                {
                    xSer.Serialize(wrt, p);
                }
    
                //Print the output
                Console.WriteLine(output.ToString());
    
    
                //Deserialize the xml string back to an instance of Person
                Person p2 = null;
                using (StringReader rdr = new StringReader(output.ToString()))
                {
                    p2 = xSer.Deserialize(rdr) as Person;
                }
    
                //Use p2 instance here
                Console.WriteLine("\r\nName: {0},  Email: {1}, has {2} phone numbers:", p2.Name, p2.Email, p2.PhoneNumbers.Count);
                foreach (var number in p2.PhoneNumbers)
                {
                    Console.WriteLine("    {0}:  {1}", number.Type, number.Number);
                }
                
                Console.ReadLine();
            }
        }
    
        [Serializable]
        [XmlInclude(typeof(PhoneNumber))]
        public class Person
        {
            public string Name { get; set; }
            public string Email { get; set; }
    
            [XmlArrayItem("Number")]
            public List<PhoneNumber> PhoneNumbers { get; set; }
    
            public Person()
            {
                PhoneNumbers = new List<PhoneNumber>();
            }
        }
    
        [Serializable]
        public class PhoneNumber
        {
            [XmlAttribute]
            public string Type { get; set; }
            [XmlText]
            public string Number { get; set; }
        }
    }
