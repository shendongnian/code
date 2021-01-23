    string[] files = new string[] { @"c:\temp\file1.txt", @"c:\temp\file2.txt" };
    var hash = new Dictionary<string, List<string>>();
    foreach (var file in files)
    {
        string[] fileContents = File.ReadAllLines(file);
        foreach (string line in fileContents)
        {
            string[] a = line.Split(',');
            if (!hash.Keys.Contains(a[0]))
                hash[a[0]] = new List<string>();
            hash[a[0]].Add(a[1]);
        }
    }
    foreach (string key in hash.Keys)
        Console.WriteLine(key + "," + string.Join(",", hash[key].ToArray()));
