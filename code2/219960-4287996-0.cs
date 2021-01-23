    var extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".bmp", ".jpg" };
    int pathLength = path.Length + 1;
    var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
        .Where(s => extensions.Contains(Path.GetExtension(s)))
        .Select(s => s.Substring(pathLength))
        .OrderBy(s => s, new FileComparer());
