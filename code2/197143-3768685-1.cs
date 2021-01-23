    Response myResponse = new Person();
    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(myResponse.GetType());
    myResponse = serializer.ReadObject(ms) as Response;
    ms.Close();
