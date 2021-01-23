    using (var ms = new MemoryStream())
    {
        using(var noClose = new NonClosingStreamWrapper(ms))
        using(var writer = BinaryWriter(noClose))
        {
            writer.Write(/*something*/);
            writer.Flush();
        }
        Assert.That(ms.Length > 0);
    }
