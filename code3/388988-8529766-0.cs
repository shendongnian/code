	var lines = File.ReadAllLines(inputPath);
    var results = new List<string>();
    foreach (var line in lines)
    {
        results.Add(string.Format("A{0}", line));
    }
    File.WriteAllLines(outputPath, results.ToArray()); 
