    DateTime someDateTime = DateTime.Now.AddDays(5);
    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(DateTime));
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    // converting to w3c xml
    ser.Serialize(ms, someDateTime);
    //**Edited**
    ms.Position = 0;
    //**Edited**
    System.IO.StreamReader sr = new System.IO.StreamReader(ms);
    string w3cxml = sr.ReadToEnd();
    
    sr.Close();
    ms.Close();
    
    // doing reverse
    System.IO.StringReader reader = new System.IO.StringReader(w3cxml);
    
    DateTime thatDateTime = (DateTime)ser.Deserialize(reader);
    
    reader.Close();
