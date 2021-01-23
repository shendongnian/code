            XmlSerializer ser = new XmlSerializer(typeof(TestClass));
            MemoryStream m = new MemoryStream();
            ser.Serialize(m, new TestClass());
            m.Seek(0, SeekOrigin.Begin);   //<-- ADD THIS!
            string xml = new StreamReader(m).ReadToEnd();
            Console.WriteLine(xml);
            Console.ReadLine();
