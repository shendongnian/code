    string path = @"C:\TestFolder";
    string charToInsert = " ";
    string[] allFiles = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly); //Directory.EnumerateFiles
    foreach (string file in allFiles)
    {
        var sb = new StringBuilder();
        string[] lines = File.ReadAllLines(file); //input file
        foreach (string line in lines)
        {
            sb.AppendLine(line.Length > 8 ? line.Substring(0, 7) + line.Substring(8) : line);
        }
        File.WriteAllText(file, sb.ToString()); //overwrite modified content
    }
