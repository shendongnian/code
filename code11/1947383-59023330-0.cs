    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase()
                {
                    Person = new Person()
                    {
                        dependants = new List<Dependant>()
                    }
                };
                XDocument doc = XDocument.Parse("<db><Person></Person></db>");
                XElement xPerson = doc.Descendants("Person").FirstOrDefault();
                Person person = db.Person;
                xPerson.Add(new object[] {
                    new XElement("id", person.id),
                    new XElement("name", person.name),
                    new XElement("dependants")
                });
                XElement xDependants = xPerson.Element("dependants");
                foreach (Dependant dependant in person.dependants)
                {
                    xDependants.Add(new XElement("dependant"), new object[] {
                        new XElement("name", dependant.name),
                        new XElement("email", dependant.email)
                    });
                }
            }
        }
        public class Person
        {
            public string id { get; set; }
            public string name { get; set; }
            public virtual ICollection<Dependant> dependants { get; set; }
        }
        public class Dependant
        {
            public string name { get; set; }
            public string email { get; set; }
        }
        public class DataBase
        {
            public Person Person { get; set; }
        }
    }
