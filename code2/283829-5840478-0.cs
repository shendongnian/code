    using System.IO;
    ...
    foreach (string file in Directory.EnumerateFiles(folderPath, "*.xml"))
    {
        string contents = File.ReadAllText(file);
    }
