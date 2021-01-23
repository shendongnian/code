    // Read string (if you do not want to use xml)
    string test = "<voltage>+100mV</voltage>";
    string measure = test.Substring(test.IndexOf('>')+1);
    measure = measure.Substring(0, measure.IndexOf('<')-1);
    // Extract measure unit
    string um = measure.Substring(measure.Length - 1);
    measure = measure.Substring(0, measure.Length - 1);
    // Get value
    double val = Double.Parse(measure);
    // Convert value according to measure unit
    switch (um.ToLower())
    {
        case "m": val /= 1E3; break;
        case "n": val /= 1E9; break;
        case "p": val /= 1E12; break;
    }
