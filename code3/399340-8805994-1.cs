    string[] files = new string[] { @"c:\temp\file1.txt", @"c:\temp\file2.txt" };
    var hash = new Dictionary<string, Dictionary<string, bool>>();
    foreach (var file in files)
    {
        string[] fileContents = File.ReadAllLines(file);
        foreach (string line in fileContents)
        {
            string[] a = line.Split(',');
            if (!hash.Keys.Contains(a[0]))
                hash[a[0]] = new Dictionary<string, bool>();
            hash[a[0]][a[1]] = true;
        }
    }
    foreach (var key in hash.Keys)
        Console.WriteLine(key + "," + string.Join(",", hash[key].Keys.ToArray()));
