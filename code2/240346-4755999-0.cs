    using System;
    using System.Xml.Linq;
    
    class Test
    {    
        static void Main()
        {
            DateTime now = DateTime.Now;
            XElement element = new XElement("Now", now);
            
            Console.WriteLine(element);
            DateTime parsed = (DateTime) element;
            Console.WriteLine(parsed);
        }
    }
