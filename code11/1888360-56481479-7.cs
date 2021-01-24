    internal bool HasEnglishCharacters(string text)
    {
        
          Regex regex = new Regex(
        
            "^[a-zA-Z0-9]*$");
        
          return regex.IsMatch(text);
    }
