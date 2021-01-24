    private static XmlDocument LoadXmlFromFile(string xmlPath)
    {
        XmlDocument doc = new XmlDocument();
        int i = 2;
        while (true)
        {
            try
            {
                using (Stream fileStream = System.IO.File.Open(xmlPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    doc.Load(fileStream);
                }
                return doc;
            }
            catch (IOException) 
            {
                i--;                  // here you need to change
                if (i > 0)
                {
                    Thread.Sleep(100);
                }    
                
            }
        }
    }
