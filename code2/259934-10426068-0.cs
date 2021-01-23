      //In A.aspx
      //Serialize.
      Object obj = MyObject;
      Session["Passing Object"] = obj;
      //In B.aspx
      //DeSerialize.
      MyObject obj1 = (MyObject)Session["Passing Object"];
      Returntype of the method xyx = obj.Method;//Using the deserialized data.
      //.............To save on your Asp project solution itself................
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
      //.............To save on client machine................
      String fileName = @"C:\MyFiles.xml";//you can keep any extension like .xyz or .yourname, anything, not an issue.
      //In A.aspx
      //Serialize.
      IFormatter formatterSerialize = new BinaryFormatter();
      Stream streamSerialize = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
      formatterSerialize.Serialize(streamSerialize, MyObject);
      streamSerialize.Close();
       //In B.aspx
      //DeSerialize.
      IFormatter formatterDeSerialize = new BinaryFormatter();
      Stream stream1 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
      MyObject obj = (MyObject)formatterDeSerialize.Deserialize(stream1);
      stream1.Close();
      Returntype of the method xyx = obj.Method;//Using the deserialized data.
