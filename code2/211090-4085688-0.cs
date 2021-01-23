    List<string> parts = name.Split(',')
                             .Select(x => x.Trim())
                             .ToList();
    string name = parts[0];
    string assembly = parts.Count < 2 ? null : parts[1];
    string version = parts.Count < 3 ? null : parts[2];
    string culture = parts.Count < 4 ? null : parts[3];
    string token = parts.Count < 5 ? null : parts[4];
    if (version != null && !version.StartsWith("Version="))
    {
        throw new ArgumentException("Invalid version: " + version);
    }
    // etc
