    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using System;
    public class Class1 { }
    public class Class2 : Class1{}
    static class Program {
    
        static void Main() {
        
            List<Class2> c2 = new List<Class2>();
            var ser = new XmlSerializer(typeof(List<Class1>), new[] {typeof(Class1), typeof(Class2)});
            List<Class1> objects = new List<Class1>(), clone;
            objects.Add(new Class2());
            objects.Add(new Class2());
            objects.Add(new Class2());
            using (var ms = new MemoryStream())
            {
                ser.Serialize(ms, objects);
                ms.Position = 0;
                clone = (List<Class1>)ser.Deserialize(ms);
            }
            Console.WriteLine(clone.Count);
        }
    }
