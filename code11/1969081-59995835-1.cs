    List<string> cells = new List<string>() { "W123", "W432", "W546,  W234,  W167" };
    List<string> keys = new List<string>();
    foreach (string cell in cells)
    {
        keys.AddRange(cell.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }
