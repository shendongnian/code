    string line = input
        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .Where(s => s.StartsWith("4TOT"))
        .FirstOrDefault();
    
    string value = string.IsNullOrEmpty(line) ? string.Empty : line.Split('|')[2];
