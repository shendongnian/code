    byte[] buffer;
    int value1 = 10;
    double value2 = 20;
    string value3 = "foo";
    
    using(var ms = new System.IO.MemoryStream())
    {
        using(var writer = new System.IO.BinaryWriter(ms))
        {
            writer.Write(value1);
            writer.Write(value2);
            writer.Write(value3);
        }
    }
    buffer = ms.ToArray();
