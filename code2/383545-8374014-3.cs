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
    
          Console.WriteLine("\n Before serializing...\n");
          Console.WriteLine(string.Format("Age = {0} Name = {1}", p.Age,p.Name));
          XDocument d = new XDocument();
          using (XmlWriter xw = d.CreateWriter())
            xs.Serialize(xw, p);
    
          // you can use LINQ on elm now
          XElement elm = d.Root;
    
          Console.WriteLine("\n From XElement...\n");
          elm.Elements().All(e => { Console.WriteLine(string.Format("element name {0} , element value {1}", e.Name, e.Value)); return true; });
    
          //deserialize back to object
          Person pDeserialized = xs.Deserialize((d.CreateReader())) as Person;
          Console.WriteLine("\n After deserializing...\n");
          Console.WriteLine(string.Format("Age = {0} Name = {1}", p.Age, p.Name));
    
          Console.ReadLine();
    
        }
      }
    
    
    }
