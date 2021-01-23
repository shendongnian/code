    private string RemoveEmptyLines(string lines)
    {
      return Regex.Replace(lines, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
    }
    
