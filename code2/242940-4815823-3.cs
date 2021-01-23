    A a = new A() {
    	Bar = 1,
    	Foo = 3
    };
    
    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(A));
    System.IO.Stream s = new System.IO.MemoryStream();
    xs.Serialize(s, a);
    
    string serial = System.Text.ASCIIEncoding.ASCII.GetString(ReadToEnd(s));
    serial = serial.Replace("<A xmlns", "<B xmlns");
    serial = serial.Replace("</A>", "</B>");
    
    s.SetLength(0);
    byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(serial);
    s.Write(bytes, 0, bytes.Length);
    s.Position = 0;
    
    xs = new System.Xml.Serialization.XmlSerializer(typeof(B));
    B b = xs.Deserialize(s) as B;
