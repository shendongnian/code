    public static IEnumerable<string> ReadAndFilter(this FileInfo info, Predicate<string> condition)
    {
        string line;
    
        using (var reader = new StreamReader(info.FullName))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (condition(line))
                {
                    yield return line;
                }
            }
        }
    }
