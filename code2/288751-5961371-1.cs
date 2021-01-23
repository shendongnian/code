    Message m = new Message();
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Message));
    // SERIALIZE
    string json;
    using (MemoryStream ms = new MemoryStream())
    {
        serializer.WriteObject(ms, m);
        StringBuilder sb = new StringBuilder();
        sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
   
        json = sb.ToString();
    }
 
    // DESERIALIZE
    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
    {
        Message deserializedMessage = serializer.ReadObject(ms) as Message;
    }
