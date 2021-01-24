    var sb = new StringBuilder();
    string path = @"E:\test\test.txt";
    string path2 = @"E:\test\test2.txt";
    string charToInsert = " ";
    string[] lines = File.ReadAllLines(path);
    foreach (string line in lines)
    {
        sb.AppendLine(line.Length > 8 ? line.Substring(0, 8) + charToInsert + line.Substring(9) : line);
    }
    File.WriteAllText(path2, sb.ToString());
