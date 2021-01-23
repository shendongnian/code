    public string HighLight (string text, string word)
    {
      int startIndex = text.indexOf (word);
      if (startIndex >= 0)
      {
        StringBuilder builder = new StringBuilder ();
        builder.Append (text.Substring ( 0, startIndex));
        builder.Append ("<strong>");
        builder.Append (text.Substring (startIndex + 1, word.Length));
        builder.Append ("</strong>");
        builder.Append (text.Substring (startIndex + word.Length + 1));
        return builder.ToString ();
      }
    
      //Word not found.
      return text;
    }
