    [Test]
    public void NewLineIsUnixStyle()
    {
        using (var text = new MemoryStream())
        using (TextWriter writer = new StreamWriter(text))
        {
            writer.NewLine = "\n";
            writer.WriteLine("SO");
            writer.Flush();
                
            text.Position = 0;
            var buffer = new byte[10];
            var b3 = buffer[3];
            Assert.AreEqual(3, text.Read(buffer, 0, 10));
            Assert.AreEqual('S', (char)buffer[0]);
            Assert.AreEqual('O', (char)buffer[1]);
            Assert.AreEqual('\n', (char)buffer[2]);
            Assert.AreEqual(b3, buffer[3]);
        }
    }
    [Test]
    public void NewLineIsSomeTextValue()
    {
        using (var text = new MemoryStream())
        using (TextWriter writer = new StreamWriter(text))
        {
            writer.NewLine = "YIPPEE!";
            writer.WriteLine("SO");
            writer.Flush();
            text.Position = 0;
            var buffer = new byte[10];
            Assert.AreEqual(9, text.Read(buffer, 0, 10));
            Assert.AreEqual('S', (char)buffer[0]);
            Assert.AreEqual('O', (char)buffer[1]);
            Assert.AreEqual('Y', (char)buffer[2]);
            Assert.AreEqual('I', (char)buffer[3]);
            Assert.AreEqual('P', (char)buffer[4]);
            Assert.AreEqual('P', (char)buffer[5]);
            Assert.AreEqual('E', (char)buffer[6]);
            Assert.AreEqual('E', (char)buffer[7]);
            Assert.AreEqual('!', (char)buffer[8]);
            Assert.AreEqual(0, buffer[9]);
        }
    }
