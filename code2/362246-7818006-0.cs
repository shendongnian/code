            XmlSerializer ser = new XmlSerializer(typeof(TestClass));
            MemoryStream m = new MemoryStream();
            ser.Serialize(m, new TestClass());
            m.Close();   //<-- ADD THIS!
            string xml = new StreamReader(m).ReadToEnd();
            Console.WriteLine(xml);
            Console.ReadLine();
