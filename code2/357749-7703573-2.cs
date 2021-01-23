    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program{
        static void Main(string[] args){
            string data = "start and dffdfdddddddfd<m>one</m><m>two</m><m>three</m><m>four</m>dbfjnbjvbnvbnjvbnv and end";
            string xmlString = "<root>" + data + "</root>";
            var doc = XDocument.Parse(xmlString);
            var ie = doc.Descendants("m");
            Console.Write("output1:");
            foreach(var el in ie){
                Console.Write(el.Value + " ");
            }
            Console.WriteLine("\noutput2:{0}",ie.Last().Value);
            Console.WriteLine("output3:{0}",ie.First().Value);
        }
    }
    
