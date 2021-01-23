    [Test]
    public void test()
    {
        byte[] input = Encoding.ASCII.GetBytes("hello");
        Stream stream1 = new MemoryStream(input);
        Stream stream2 = new MemoryStream();
        //Copy stream 1 to stream 2
        stream1.CopyTo(stream2);
                           
        byte[] output = new byte[input.Length];
        stream2.Position = 0;
        stream2.Read(output, 0, output.Length);
        Console.WriteLine(Encoding.ASCII.GetString(output));
    }
