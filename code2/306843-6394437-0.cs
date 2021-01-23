    private void UpdateVersion(string file, string version)
    {
        string[] asmInfo = File.ReadAllLines(file);
        asmInfo = asmInfo.Select(x => x.Trim().StartsWith("[assembly: AssemblyVersion") ?
            "[assembly: AssemblyVersion\"" + version + "\")]" : x).ToArray();
        File.WriteAllLines(file, asmInfo);
    }
 
