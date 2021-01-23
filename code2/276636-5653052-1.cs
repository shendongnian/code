    public static byte[] Foo()
    {
        using (var memStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memStream))
        {
            for (int i = 0; i < 6; i++)
                streamWriter.WriteLine("TEST");
    
            streamWriter.Flush();
            return memStream.ToArray();
        }
    }
    
    [Test]
    public void TestStreamRowCount()
    {
        var bytes = Foo();
    
        using (var stream = new MemoryStream(bytes))
        using (var reader = new StreamReader(stream))
        {
            var collection = new List<string>();
            string input;
    
            while ((input = reader.ReadLine()) != null)
                collection.Add(input);
    
            Assert.AreEqual(6, collection.Count);
        }
    }
