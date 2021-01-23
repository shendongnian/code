    context.Response.ContentType = "application/json";
    MyDataType someObject = new MyDataType();
    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MyDataType));
    using (MemoryStream ms = new MemoryStream())
    {
        ser.WriteObject(ms, data);
        ms.Seek(0, SeekOrigin.Begin);
    
        StreamReader sr = new StreamReader(ms);
        string json = sr.ReadToEnd();
        Trace("Returning JSON:\n" + json + "\n");
        context.Response.Write(json);
    }
