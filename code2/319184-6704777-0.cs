            var result = XDocument.Load("test.xml").Descendants("param");
            foreach (var p in result)
            {
                Console.WriteLine(p.Attribute("name"));
            }
            
            Console.Read();
