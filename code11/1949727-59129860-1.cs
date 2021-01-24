    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<Car> myList = new List<Car>();
                myList.Add(new Car(){ Name = "Beetle", Brand = "VW", Price = 5999.9M });
                myList.Add(new Car(){ Name = "Corolla", Brand = "Toyota", Price = 49999.9M });
    
                Saveclass.Save("carlist.xml",myList);
            }
        }
    
        public static class Saveclass
        {
            public static void Save(string filename, List<Car> classlist)
            {
                StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                serializer.Serialize(writer,classlist);
                writer.Close();
            }
        }
        public class Car
        {
          public string Name  {get;set;}
          public string Brand  {get; set;}
          public decimal Price {get; set;}
        }
    }
