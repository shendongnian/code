    [Test]
    public void test()
    {
        string inString = "bling";
        byte[] inBuffer = Encoding.ASCII.GetBytes(inString);
        Stream stream1 = new MemoryStream(inBuffer);
        Stream stream2 = new MemoryStream();
        //Copy stream 1 to stream 2
        stream1.CopyTo(stream2);
            
        byte[] outBuffer = new byte[inBuffer.Length];
        stream2.Position = 0;        
        stream2.Read(outBuffer, 0, outBuffer.Length);
        string outString = Encoding.ASCII.GetString(outBuffer);
 
        Assert.AreEqual(inString, outString, "inString equals outString.");
    }
