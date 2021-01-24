    byte[] bytes = Encoding.UTF8.GetBytes(str);
    writer.Write(bytes.Length);
    writer.Write(bytes);  
    int len = reader.ReadInt32();
    byte[] bytes = reader.ReadBytes(len);
    string str = Encoding.UTF8.GetString(bytes);
