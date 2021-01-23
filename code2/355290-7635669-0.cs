       private XDocument Serialize<T>(object obj)
        {
            XDocument ReturnValue = new XDocument();
        
            XmlSerializer Serializer = new XmlSerializer(typeof(T));
            System.IO.StringWriter sw = new System.IO.StringWriter();        
            System.IO.StringReader sr; 
            Serializer.Serialize(sw, obj);
            sr = new System.IO.StringReader(sw.ToString());
            ReturnValue = XDocument.Load(sr);
            return ReturnValue;
        }
