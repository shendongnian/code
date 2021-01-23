    class Program
    {
        static readonly string path = @"C:\Users\Dmitry\Documents\test_3.xml";
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                test(path);
        }
        static void test(string path)
        {
            XmlDocument document = new XmlDocument();
            if (File.Exists(path))
            {
                using (Stream readStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    document.Load(readStream);
                }
            }
            else
            {                
                document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", String.Empty));
                document.AppendChild(document.CreateElement("Test"));
            }
            document.DocumentElement.AppendChild(document.CreateElement("Node"));
            using (FileStream WRITER = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                document.Save(WRITER);
            }
        }
    }
