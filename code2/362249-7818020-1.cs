            XmlSerializer ser = new XmlSerializer(typeof(TestClass));
            string xml;
            using (MemoryStream m = new MemoryStream())
            {
                ser.Serialize(m, new TestClass());
                // reset to 0
                m.Position = 0;
                xml = new StreamReader(m).ReadToEnd();
            }
            Console.WriteLine(xml);
            Console.ReadLine();
