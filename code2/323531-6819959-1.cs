    foreach (var xyLine in mainResult) {
        //PLACEMENT TWO Regex
        Match xyRegex = Regex.Match(xyLine, @"([\d]+\.[\d]+)\s+([\d]+\.[\d]+)");
        if (xyRegex.Success) {
            xResult.Add(xyRegex.Groups[1].Value);
            yResult.Add(xyRegex.Groups[2].Value);
        }
    }
