    public static XmlDocument GrabXmlDocFromStream(StreamReader reader)
    {
        using(MemoryStream ms = new MemoryStream())
        {
            byte b = 0;
            while(!reader.EndOfStream)
            {
                b = (byte)reader.Read();
                ms.WriteByte(b);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
    
                using(XmlReader xmlreader = XmlReader.Create(ms))
                {
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        if(Encoding.ASCII.GetChars(new byte[1] { b })[0] == '>')
                        {
                            if(xmlreader.Read())
                            {
                                XmlDocument objXmlDocument = new XmlDocument();
                                objXmlDocument.Load(xmlreader);
                                return objXmlDocument;
                            }
                        }
                    }
                    catch(XmlException xe) { }
                }
            }
        }
        return null;
    }
