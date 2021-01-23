    // filter out lines to use
    var linesToUse = input
        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
        .Where(s => s.StartsWith("4TOT"));
    
    foreach (string line in linesToUse)
    {
        // pick out the value
        string valueToUse = line.Split('|')[2];
        // more code here, I guess
    }
