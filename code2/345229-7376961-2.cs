    var textBytes = Encoding.ASCII.GetBytes("Test123");
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileNoCloseNoFlush.txt", FileMode.CreateNew))
    {
        fileTest.Write(textBytes,0,textBytes.Length);
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileCloseNoFlush.txt", FileMode.CreateNew))
    {
        fileTest.Write(textBytes, 0, textBytes.Length);
        fileTest.Close();
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileFlushNoClose.txt", FileMode.CreateNew))
    {
        fileTest.Write(textBytes, 0, textBytes.Length);
        fileTest.Flush();
    }
    using (var fileTest = System.IO.File.Open(@"c:\temp\fileCloseAndFlush.txt", FileMode.CreateNew))
    {
        fileTest.Write(textBytes, 0, textBytes.Length);
        fileTest.Flush();
        fileTest.Close();
    }
