    public T ActOnFile<T>(string filename, Func<Stream, T> func)
    {
        using (Stream stream = File.OpenRead(stream))
        {
            return func(stream);
        }
    }
    public int CountLines(string filename)
    {
        return ActOnFile(filename, stream =>
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                int count = 0;
                while (reader.ReadLine() != null)
                {
                    count++;
                }
                return count;
            }
        });
    }
