    StreamWriter writer = new StreamWriter("file");
    public void WriteValues(IEnumerable<double> values)
    {
        lock (writer)
        {
            foreach (var d in values)
            {
                writer.WriteLine(d);
            }
            writer.Flush();
        }
    }
