    string xml = File.ReadAllText("text.xml");
    byte[] bytes = Encoding.ASCII.GetBytes(xml);
    StringBuilder sb = new StringBuilder();
    
    foreach (byte b in bytes)
    {
          sb.AppendFormat("{0:x2}", b);
    }
    
    File.WriteAllText("test2.txt", sb.ToString());
