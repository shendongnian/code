    public int CountLines(string filename)
    {
        using (var reader = File.OpenText(filename))
        {
            int count = 0;
            while (reader.ReadLine() != null)
            {
                count++;
            }
            return count;
        }
    }
