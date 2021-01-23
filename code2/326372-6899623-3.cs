    public string HighLight (int startPoint, string text, string word)
    {
      if (startPoint > = 0)
      {
        int startIndex = text.indexOf (word, startPoint);
        if (startIndex >= 0)
        {
          StringBuilder builder = new StringBuilder ();
          builder.Append (text.Substring ( 0, startIndex));
          builder.Append ("<strong>");
          builder.Append (text.Substring (startIndex + 1, word.Length));
          builder.Append ("</strong>");
          builder.Append (text.Substring (startIndex + word.Length + 1));
          return HighLight ((startIndex + "<strong>".Length + "</strong>".Length + word.Length, builder.ToString (), word);
        }
      }
    
      //Word not found.
      return text;
    }
