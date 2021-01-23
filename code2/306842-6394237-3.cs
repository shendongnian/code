    private static void UpdateVersion(string file, string version)
    {
        var linesList = File.ReadAllLines(file).ToList();
        var line = linesList.Single(x => x.Trim().StartsWith("[assembly: AssemblyVersion"));
        linesList.Remove(line);
        linesList.Add("[assembly: AssemblyVersion(\"" + version + "\")]");
        File.WriteAllLines(file, linesList.ToArray());
    }
