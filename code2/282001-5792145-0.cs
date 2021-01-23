    string xml = File.ReadAllText("text.xml");
    byte[] bytes = Encoding.ASCII.GetBytes(xml);
    StringBuilder sb = new StringBuilder();
    
    foreach (byte b in bytes)
    {
        sb.Append(Convert.ToString(b, 2));
    }
    
    File.WriteAllText("test2.txt", sb.ToString());
