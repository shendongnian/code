    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    
    class Program{
        static void Main(){
            var doc = XDocument.Load("1.xml");
            var result = (from node in doc.Root.Elements()
                         select new{ Key = node.Name, Value = node.Attribute("value").Value})
                         .ToDictionary(p =>p.Key, p=>p.Value);
            foreach(var p in result) Console.WriteLine("{0}=>{1}", p.Key, p.Value);
        }
    }
