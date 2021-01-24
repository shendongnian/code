    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\teest1.xml";
            var doc = LoadXmlFromFile(path);
        }
        private static XmlDocument LoadXmlFromFile(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            int i = 2;
            while (i>=0)              // change the while sentence
            {
                try
                {
                    using (Stream fileStream = System.IO.File.Open(xmlPath, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        doc.Load(fileStream);
                    }
                    return doc;
                }
                catch (IOException ex)
                {             
                    if (i == 0)
                    {
                        throw ex;
                    }
                  
                    i--;
                    Thread.Sleep(200);
                }
            
            }
            return doc;
        }
     
    }
