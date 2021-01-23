    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.IO;
    
    
    namespace ConsoleApplication5
    {
      public class Person
      {
        public int Age { get; set; }
        public string Name { get; set; }
        public int XMLLine { get; set; }
      }
      public class Persons : List<Person> { }
    
      class Program
      {
    
        static void Main(string[] args)
        {
          //create your objects
    
          Person p = new Person();
          p.Age = 35;
          p.Name = "Arnold";
    
          Person p2 = new Person();
          p2.Age = 36;
          p2.Name = "Tom";
    
          Persons ps = new Persons();
          ps.Add(p);
          ps.Add(p2);
    
          //Serialize them to XML
    
          XmlSerializer xs = new XmlSerializer(typeof(Persons));
    
          XDocument d = new XDocument();
    
          using (XmlWriter xw = d.CreateWriter())
            xs.Serialize(xw, ps);
    
          //print xml
          //System.Diagnostics.Debug.WriteLine(d.ToString());
    
          // it will produce following xml. You can save it to file.
          //I have saved it to variable xml for demo
    
    
    
          string xml = @"<ArrayOfPerson>
                          <Person>
                            <Age>35</Age>
                            <Name>Arnold</Name>
                            <XMLLine>0</XMLLine>
                         </Person> 
                         <Person>
                           <Age>36</Age>
                           <Name>Tom</Name>
                           <XMLLine>0</XMLLine>
                          </Person>
                        </ArrayOfPerson>";
    
    
    
          XDocument xdoc = XDocument.Parse(xml, LoadOptions.SetLineInfo);
          // A little trick to get xml line
          xdoc.Descendants("Person").All(a => { a.SetElementValue("XMLLine", ((IXmlLineInfo)a).HasLineInfo() ? ((IXmlLineInfo)a).LineNumber : -1); return true; });
          
          
          //deserialize back to object
    
          Persons pplz = xs.Deserialize((xdoc.CreateReader())) as Persons;
    
          pplz.All(a => { Console.WriteLine(string.Format("Name {0} ,Age{1} ,Line number of object in XML File {2}", a.Name, a.Age, a.XMLLine)); return true; });
    
          Console.ReadLine();
    
        }
      }
    }
