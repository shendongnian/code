    static IEnumerable<(int, int[])> CreateDataSet(string DatasetPath)
    {
        var result = new List<(int, int[])> = new List<(int, int[])>();
        foreach(string line in File.ReadLines(DatasetPath))
        {
            var lineData = line.Split('|');            
            yield return (int.Parse(linedata[1]), FlattenArray(ImageToArray(lineData[0])) );
        }
    }
