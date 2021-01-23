    private string RemoveEmptyLines(string lines)
    {
      return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
    }
    
