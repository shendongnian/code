    using (Stream s = new Stream("application.log")
    {
       using(var b = new BinaryWriter(s))
       {
        b.Write(new byte[] { 1, 2, 3, 4, 5 });
       }
    }
