    byte[] bytes;
    using (var img = File.OpenRead("message.msg"))
    {
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            bytes = memoryStream.ToArray();
        }
    }
