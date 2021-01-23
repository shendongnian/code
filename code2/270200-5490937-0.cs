    var OutputArray = new byte[items.Length * 4];
    using (var ms = new MemoryStream(OutputArray))
    {
        using (var writer = new BinaryWriter(ms))
        {
            foreach (var i in items)
            {
                writer.Write(i);
            }
        }
    }
    // You can now send the OutputArray to SQL server
