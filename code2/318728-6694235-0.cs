    string input = "x\t\ty\t\t\tz";
    char[] separator = new char[] { '\t' };
    string[] result1 = input.Split(separator, StringSplitOptions.None);
    // result1 == new string[] { "x", "", "y", "", "", "z" }
    string[] result2 = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    // result2 == new string[] { "x", "y", "z" }
