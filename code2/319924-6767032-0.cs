    var memoryStream = new MemoryStream();
    var binaryFormatter = new BinaryFormatter();
    binaryFormatter.Serialize(memoryStream, m_workspace.ListPlatforms.ToArray());
    
    String base64String = Convert.ToBase64String(memoryStream.ToArray());
