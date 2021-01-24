    List<List<MyClass>> data = new List<List<MyClass>>();
    using (CsvDataReader<MyClass> reader = new CsvDataReader<MyClass>(path))
    {
        reader.ReadHeaders(true);
        data.Add(new List<MyClass>());
        while (reader.Read(out MyClass item))
        {
            if (reader.ColumnCount == 0)
                data.Add(new List<MyClass>());
            else
                data[data.Count - 1].Add(item);
        }
    }
