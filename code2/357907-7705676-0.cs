    using (var streamReader = new StreamReader(filePath, Encoding.Default))
    {
        while (!streamReader.EndOfStream)
        {
            StoreItems.Add(streamReader.ReadLine());
        }
    }
    StoreItems.RemoveAll(item => item == textBox1.Text);
    using (var streamWriter = new StreamWriter(filePath, false, Encoding.Default))
    {
        foreach (string line in StoreItems)
        {
            streamWrite.WriteLine(line);
        }
    }
