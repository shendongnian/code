    private void Test()
    {            
        System.IO.MemoryStream data = new System.IO.MemoryStream(TestStream());
        byte[] buf = new byte[data.Length];
        data.Read(buf, 0, buf.Length);                       
    }
