            string msg = "<response><point><x>12557735.513928</x><y>5500887.2196169</y><projection>EPSG::29873</projection></point></response>";             
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(msg);
            var valueX = doc.GetElementsByTagName("x")[0].InnerText;
            string valueY = doc.GetElementsByTagName("y")[0].InnerText;
            Console.WriteLine("TEST");
            Console.WriteLine("Timb East" + valueX);
            Console.WriteLine("Timb North" + valueY);
