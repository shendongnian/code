    List<string> lines = new List<string> (File.ReadAllLines("Tags.txt"));
    lines.RemoveAll(line => !Regex.IsMatch(line, @"^Line\s+\d+:");
    using (StreamWriter fw = new StreamWriter(new FileStream("TagsNew.txt", FileMode.CreateNew, FileAccess.Write)))
    {
       foreach (string line in lines)
       {
           fw.WriteLine(line);
       }
    }
