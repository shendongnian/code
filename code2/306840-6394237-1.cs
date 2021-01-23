    private static void UpdateVersion(string file, string version)
    {
        var fileContent = File.ReadAllText(file);
        var newFileContent = Regex.Replace(
            fileContent,
            @"(?<=AssemblyVersion\("")(?<VersionGroup>.*?)(?=""\))",
            version);
        File.WriteAllText(file, newFileContent);
    }
