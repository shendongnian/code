    var obj = new MyContract();
    
    var serializer = new DataContractSerializer(typeof(MyContract));
    
    using (var ms = new MemoryStream())
    {
        serializer.WriteObject(ms, obj);
    
        ms.Seek(0, SeekOrigin.Begin);
    
        var result = serializer.ReadObject(ms) as MyContract;
    
        result.List.Add("a");
    }
