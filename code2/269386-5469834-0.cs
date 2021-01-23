    class Program
    {
        static void Main(string[] args)
        {
            string unformattedXml = @"<datas><data1>sampledata1</data1></datas>";
            XmlReader rdr = XmlReader.Create(new StringReader(unformattedXml));
            StringBuilder sb = new StringBuilder();
            
            XmlWriterSettings xmlSettingsWithIndentation = 
                new XmlWriterSettings 
                { 
                    Indent = true
                };
            using (XmlWriter writer = XmlWriter.Create(sb, xmlSettingsWithIndentation))
            {
                writer.WriteNode(rdr, true);
            }
            Console.WriteLine(sb);
            Console.ReadKey();
        }
    }
