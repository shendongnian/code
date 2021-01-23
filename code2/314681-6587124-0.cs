    try
    {
        var formatter = new BinaryFormatter();
        byte[] content;
        using (var ms = new MemoryStream())
        {
             using (var ds = new DeflateStream(ms, CompressionMode.Compress, true))
             {
                 formatter.Serialize(ds, set);
             }
             ms.Position = 0;
             content = ms.GetBuffer();
             contentAsString = BytesToString(content);
         }
    }
    catch (Exception ex) { /* handle exception omitted */ }
