    public IEnumerable<Row> ReadRows<TRowFactory>(Stream stream)
        where TRowFactory : Factory, new()
    {
        var factory = new TRowFactory();
        var numRows = stream.Length / factory.GetLength();
        for (long i = 0; i < numRows; i++)
            yield return factory.Read(stream);
    }
    // Example call...
    var rowsInFile = ReadRows<DerivedRowFactory>(File.Open(...));
