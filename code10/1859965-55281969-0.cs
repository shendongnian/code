    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication106
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Mesh> mesh = doc.Descendants("Mesh").Select(x => new Mesh()
                {
                    id = (string)x.Attribute("id"),
                    vertexes = x.Elements("Vertex").Select(y => ((string)y.Attribute("position")).Split(new char[] {','}).Select(z => decimal.Parse(z)).ToList()).ToList(),
                    faces = x.Elements("Face").Select(y => ((string)y.Attribute("vertices")).Split(new char[] { ',' }).Select(z => int.Parse(z)).ToList()).ToList(),
                }).ToList();
            }
     
        }
        public class Mesh
        {
            public string id { get; set; }
            public List<List<decimal>> vertexes { get; set; }
            public List<List<int>> faces { get; set; }
        }
    }
