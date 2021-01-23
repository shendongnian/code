    var rnd = new Random();
    var size = 1024*1024*10;
    var randomBytes = new byte[size];
    rnd.NextBytes(randomBytes);
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileNoCloseNoFlush.bin", FileMode.CreateNew))
    {
        fileTest.Write(randomBytes, 0, randomBytes.Length);
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileCloseNoFlush.bin", FileMode.CreateNew))
    {
        fileTest.Write(randomBytes, 0, randomBytes.Length);
        fileTest.Close();
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileFlushNoClose.bin", FileMode.CreateNew))
    {
        fileTest.Write(randomBytes, 0, randomBytes.Length);
        fileTest.Flush();
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileCloseAndFlush.bin", FileMode.CreateNew))
    {
        fileTest.Write(randomBytes, 0, randomBytes.Length);
        fileTest.Flush();
        fileTest.Close();
    }
