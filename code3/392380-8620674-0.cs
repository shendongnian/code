    List<string> variables = new List<string>();
    
    foreach (string sLine in assignment_lines)
    {
       variables.AddRange(sLine.Split('='));
    }
    
    // If you need an array, you can then use variables.ToArray, I believe.
