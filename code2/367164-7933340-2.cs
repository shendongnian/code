    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace ConsoleApplication8
    {
        public class Player
        {
            public string Name { get; set; }
            public int level { get; set; }
            public int cash { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                //  you may have several players like below 
                List<Player> players = new List<Player>() { 
                    new Player() { Name = "John", cash = 3, level = 215 }, 
                    new Player() { Name = "Mike", level = 7, cash = 780 } 
                };
    
                // save them to Xml file 
    
                Save("players.xml", players);
    
                //when you need details of a given player "Mike"
                Player PlayerMike = Load("players.xml", "Mike");
    
                // continue with the rest..
    
            }
    
            /// <summary>
            /// Saves the specified XML file with players data
            /// </summary>
            /// <param name="xmlFile">The XML file.</param>
            /// <param name="Players">The players.</param>
            public static void Save(string xmlFile, List<Player> Players)
            {
                XElement xml = new XElement("Players",
                                from p in Players
                                select new XElement("Player",
                                     new XElement("Name", p.Name),
                                    new XElement("level", p.level),
                                    new XElement("cash", p.cash)));
    
                xml.Save(xmlFile);
    
            }
    
            /// <summary>
            /// Loads the specified XML file.
            /// </summary>
            /// <param name="xmlFile">The XML file.</param>
            /// <returns></returns>
            public static Player Load(string xmlFile, string name)
            {
                XDocument doc = XDocument.Load(xmlFile);
    
                var query = (from xElem in doc.Descendants("Player")
                            where xElem.Element("Name").Value.Equals(name)
                            select new Player
                            {
                                Name = xElem.Element("Name").Value,
                                level = int.Parse(xElem.Element("level").Value),
                                cash =  int.Parse(xElem.Element("cash").Value),
                            }).FirstOrDefault();
                return query;
            }     
    
        }
    }
