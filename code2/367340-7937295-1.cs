    class person 
    { 
    ; 
    } 
     
    person p = new person(); 
    using (MemoryStream ms = new MemoryStream())     
    {
        XmlSerializer ser = new XmlSerializer(p.GetType()); 
        ser.Serialize(ms,p) 
     
        ms.Seek(0, SeekOrigin.Begin); 
     
        XmlDictionaryReader xdr = XmlDictionaryReader.CreateTextReader(ms,new XmlDictionaryReaderQuotas());
    }
