    string path = "file path here";
    List<string> lines = File.ReadAllLines(path).ToList();
    lines.RemoveAll(line => line.Equals(requested));
    lines.Add(newname);
    File.WriteAllLines(path, lines);
