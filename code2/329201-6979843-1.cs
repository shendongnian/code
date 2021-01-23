    public string ObjectToString(object obj)
    {
      MemoryStream ms = new MemoryStream()
      new BinaryFormatter().Serialize(ms, obj);         
      return Convert.ToBase64String(ms.ToArray());
    }
    public object StringToObject(string base64String)
    {    
      byte[] bytes = Convert.FromBase64String(base64String);
      MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);    
      ms.Write(bytes, 0, bytes.Length);
      ms.Position = 0;
      return new BinaryFormatter().Deserialize(ms);
    }
