    string path = @"E:\test\testFolder";
    string charToInsert = " ";
    string[] allFiles = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly); //Directory.EnumerateFiles
    foreach (string file in allFiles)
    {
        var sb = new StringBuilder();
        string[] lines = File.ReadAllLines(file); //input file
        foreach (string line in lines)
        {
            sb.AppendLine(line.Length > 8 ? line.Substring(0, 8) + charToInsert + line.Substring(9) : line);
        }
        File.WriteAllText(file, sb.ToString()); //overwrite modified content
    }
