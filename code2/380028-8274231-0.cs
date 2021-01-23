    Dictionary<string, object> uniqueLines = new Dictionary<string, object>();
    foreach (string line in File.ReadAllLines(filename)) {
        uniqueLines[line] = null;
    }
    int numberOfUniqueLines = uniqueLines.Keys.Count;
 
