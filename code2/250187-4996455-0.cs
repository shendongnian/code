    using System;
    using System.Text.RegularExpressions;
    string pattern = @"\bAAAA\b|\bAAZ\w\b|\bAA\wZ\b|\bA\wZZ\b|\b\wAZZ\b";
    // 1 Declare new List.
    List<string> lines = new List<string>();
    // 2
    // Use using StreamReader for disposing.
    using (StreamReader sr = new StreamReader(PATH))
    {
        // 3
        // Use while != null pattern for loop
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            // 4
            if (Regex.IsMatch(line, pattern, RegexOptions.IgnoreCase))
            {
                // ...
                // "line" is a line in the file. Add it to our List.
                lines.Add(line);
            }
        }
    }
