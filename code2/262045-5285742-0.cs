    public int[] ImportDat(string path)
    {
        List<int> result = File.ReadAllLines(path)
                               .Select(line => line.Split(','))
                               .SelectMany(s => s)
                               .Select( s=> Convert.ToInt32(s))
                               .ToList();
        return result;
    }
