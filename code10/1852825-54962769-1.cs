    string[] coordinatesVal = coordinateTxt.Trim().Split(new string[] { ",0" }, 
    StringSplitOptions.RemoveEmptyEntries);
    string result = string.Empty;
    foreach (string line in coordinatesVal)
    {
        string[] numbers = line.Trim().Split(',');
        result += numbers[0] + " " + numbers[1] + ", ";
    }
    result = result.Remove(result.Count()-2, 2);
