            string xml = @"<?xml version='1.0' encoding='utf-8'?>
                           <root>
                           <date>12/03/2001</date>
                           <child>
                             <name>Aravind</name>
                             <date>12/03/2000</date>
                           </child>
                           <name>AS-CII</name>
                           </root>";
            XDocument doc = XDocument.Parse(xml);
            foreach (var date in doc.Descendants("date"))
            {
                Console.WriteLine(date.Value);
            }
            foreach (var date in doc.Descendants("name"))
            {
                Console.WriteLine(date.Value);
            }
            Console.ReadLine();
