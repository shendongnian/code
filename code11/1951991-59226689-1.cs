    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Racun> racuni = new List<Racun>() {
                    new Racun() { 
                        datumkreiranjaracuna = DateTime.Now,
                        nazivulja = "suncokretovo",
                        kolicinaulja = 50,
                        cijenaulja = 25
                    },
                    new Racun() { 
                        datumkreiranjaracuna = DateTime.Now.AddDays(1),
                        nazivulja = "suncokretovo",
                        kolicinaulja = 60,
                        cijenaulja = 30
                    },
                    new Racun() { 
                        datumkreiranjaracuna = DateTime.Now.AddDays(2),
                        nazivulja = "suncokretovo",
                        kolicinaulja = 70,
                        cijenaulja = 35
                    }
                };
                string xmlIdent = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Racuni></Racuni>";
                XDocument doc = XDocument.Parse(xmlIdent);
                XElement xRacuni = doc.Root;
                foreach (Racun racun in racuni)
                {
                    XElement newRacun = new XElement("Racun", new object[] {
                        new XElement("datumkreiranjaracuna", racun.datumkreiranjaracuna.ToString("yyyyMMdd")),
                        new XElement("nazivulja", racun.nazivulja),
                        new XElement("kolicinaulja", racun.kolicinaulja),
                        new XElement("cijenaulja", racun.cijenaulja)
                    });
                    xRacuni.Add(newRacun);
                }
                doc.Save(FILENAME);
            }
        }
        public class Racun
        {
            public DateTime datumkreiranjaracuna { get; set; }
            public string nazivulja { get; set; }
            public int kolicinaulja { get; set; }
            public int cijenaulja { get; set; }
        }
    }
