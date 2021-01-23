    //Create a folder in your asp project solution with name "MyFile.bin"
    //In A.aspx
    //Serialize.
    IFormatter formatterSerialize = new BinaryFormatter();
    Stream streamSerialize = new FileStream(Server.MapPath("MyFile.bin/MyFiles.xml"), FileMode.Create, FileAccess.Write, FileShare.None);
    formatterSerialize.Serialize(streamSerialize, MyObject);
    streamSerialize.Close();
    
    //In B.aspx
    //DeSerialize.
    IFormatter formatterDeSerialize = new BinaryFormatter();
    Stream streamDeSerialize = new FileStream(Server.MapPath("MyFile.bin/MyFiles.xml"), FileMode.Open, FileAccess.Read, FileShare.Read);
    MyObject obj = (MyObject)formatterDeSerialize.Deserialize(streamDeSerialize);
    streamDeSerialize.Close();
    
    Returntype of the method xyx = obj.Method;//Using the deserialized data.
