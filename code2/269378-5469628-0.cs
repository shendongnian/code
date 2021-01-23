    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    using System.Xml.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                String name = "Morten";
                Int32 age = 30;
                String city = "Copenhagen";
                String country = "Denmark";
    
                XElement xml = new XElement("Method", 
                    new XAttribute("ID", 1), 
                    new XAttribute("Cmd", "New"),
                    new XElement("Field", 
                        new XAttribute("Name", "Name"), 
                        name),
                    new XElement("Field", 
                        new XAttribute("Name", "Age"), 
                        age),
                    new XElement("Field", 
                        new XAttribute("Name", "City"), 
                        city),
                    new XElement("Field", 
                        new XAttribute("Name", "Country"), 
                        country)
                );
    
                Console.WriteLine(xml);
                Console.ReadKey();
            }
        }
    }
