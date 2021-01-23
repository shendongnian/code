    private IEnumerable<Tuple<int, int>> ReadFile(string filePath, 
        Encoding encoding)
    {
        using (var sr = new StreamReader(filePath, encoding))
        {
            string line;
            while ((line = sr.ReadLine()) != null) 
            {
                var split = line.Split(' ');
                var w = split.Length > 0 ? int.Parse(split[0]) : 0;
                var h = split.Length > 1 ? int.Parse(split[1]) : 0;
                yield return Tuple.Create(h, w);
            }
        }
    }
