            XmlDocument xmlOut = new XmlDocument(); 
            //note: not read only
            using (FileStream outfs = new FileStream(tempOutXmlFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(outfs, Encoding.UTF8))
            {
                xmlOut.Load(reader);
            }
            using (StreamWriter writer = new StreamWriter(tempOutXmlFileName, false, Encoding.UTF8))
            {
                xmlOut.Save(writer);
            }
   
