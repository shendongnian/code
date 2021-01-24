     System.Xml.Linq.XElement xml = System.Xml.Linq.XElement.Parse("<response><point><x>12557735.513928</x><y>5500887.2196169</y><projection>EPSG::29873</projection></point></response>");
              
                var valueX = xml.Descendants().SingleOrDefault(x => x.Name.LocalName == "x")?.Value;
                var valueY = xml.Descendants().SingleOrDefault(x => x.Name.LocalName == "y")?.Value;
                Console.WriteLine("TEST");
                Console.WriteLine("Timb East" + valueX);
                Console.WriteLine("Timb North" + valueY);
