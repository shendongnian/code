    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program{
        static void Main(string[] args){
            string data = "start and dffdfdddddddfd<m>one</m><m>two</m><m>three</m><m>four</m>dbfjnbjvbnvbnjvbnv and end";
            string xmlString = "<root>" + data + "</root>";
            var doc = XDocument.Parse(xmlString);
            foreach(var el in doc.Descendants("m").Take(3)){
                Console.WriteLine(el.Value);
            }
        }
    }
    
