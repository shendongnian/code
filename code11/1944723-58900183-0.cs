    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Otazka[] otazka = LoadXMLData(FILENAME);
            }
            static Otazka[] LoadXMLData(string filename)
            {
                using (var stream = File.OpenRead(filename))
                {
                    StreamReader reader = new StreamReader(stream);
                    reader.ReadLine();  //read line to skip xml identification line which is utf-8
                                        //file contains unicode characters
                    XDocument doc = XDocument.Load(reader);
                    //_Counter = doc.ToString().Length;
                    var result = (from q in doc.Descendants("Otazka")
                                 select new Otazka
                                 {
                                     Typ = q.Element("Typ").Value,
                                     Bodu = Convert.ToInt32(q.Element("Bodu").Value),
                                     Ukol = q.Element("Ukol").Value,
                                     //Moznosti = new Moznosti(q.Element("Moznosti").Elements().Select(x => x.Value).ToList()),
                                     Spravna = q.Element("Spravna").Value
                                 }).ToArray();
                    return result;
                }
            }
        }
        public class Otazka
        {
            [XmlElement(ElementName = "Typ")]
            public string Typ { get; set; }
            [XmlElement(ElementName = "Bodu")]
            public int Bodu { get; set; }
            [XmlElement(ElementName = "Ukol")]
            public string Ukol { get; set; }
            //[XmlElement(ElementName = "Moznosti")]
            //public Moznosti Moznosti { get; set; }
            [XmlElement(ElementName = "Spravna")]
            public string Spravna { get; set; }
        }
        [XmlRoot(ElementName = "Otazky")]
        public class Otazky
        {
            [XmlElement(ElementName = "Otazka")]
            public List<Otazka> Otazka { get; set; }
        }
    }
