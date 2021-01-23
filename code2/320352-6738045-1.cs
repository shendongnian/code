        private static void Main()
        {
            StringWriter dataOut = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(dataOut);
            writer.Formatting = Formatting.Indented;
            Page p = new Page();
            p.introCommand = new PlayElement();
            
            new XmlSerializer(typeof(Page)).Serialize(writer, p);
            string xml = dataOut.ToString();
            Console.WriteLine(xml);
            XmlTextReader reader = new XmlTextReader(new StringReader(xml));
            Page copy = (Page) new XmlSerializer(typeof (Page)).Deserialize(reader);
        }
