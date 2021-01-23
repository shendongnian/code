    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    
    namespace ConsoleApplication5
    {
      public class Person
      {
        public int Age { get; set; }
        public string Name { get; set; }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
    
          XmlSerializer xs = new XmlSerializer(typeof(Person));
    
          Person p = new Person();
          p.Age = 35;
          p.Name = "Arnold";
    
          XDocument d = new XDocument();
          using (XmlWriter xw = d.CreateWriter())
            xs.Serialize(xw, p);
    
          XElement elm = d.Root;
          elm.Elements().All(e => { Console.WriteLine(string.Format("element name {0} , element value {1}", e.Name, e.Value)); return true; });
          Console.ReadLine();
    
        }
      }
    
    
    }
