    List<Part> parts = new List<Part>();
    //... populate parts
    XmlSerializer xs = new XmlSerializer(typeof(List<Part>));
    
    MemoryStream ms = new MemoryStream();
    xs.Serialize(ms, parts);
    
    // Rewind the stream and write it to session as XML
    
    ms.Seek(0, SeekOrigin.Begin);
    Session["XMLResults"] = Encoding.ASCII.GetString(ms.ToArray());
    
    //Get memory stream from session
    ms = new MemoryStream();
    byte[] bData = Encoding.ASCII.GetBytes(Session["XMLResults"].ToString());
    ms.Write(bData, 0, bData.Length);
    // Hydrate parts list from a memory stream
    ms.Seek(0, SeekOrigin.Begin);
    parts = (List<Part>)xs.Deserialize(ms);
