    static public int CountDistinctWords(this string text)
    {
      string str = text.Replace(Environment.NewLine, " ");
      var builder = new StringBuilder();
      char charLast = ' ';
      char charCurrent;
      var words = new List<string>();
      for ( int index = 0; index < str.Length; index++ )
      {
        charCurrent = str[index];
        if ( char.IsLetter(charCurrent) )
          builder.Append(charCurrent);
        else
        if ( !char.IsNumber(charCurrent) )
          charCurrent = ' ';
        if ( char.IsWhiteSpace(charCurrent) && !char.IsWhiteSpace(charLast) )
        {
          var word = builder.ToString();
          if ( !words.Contains(word) && !string.IsNullOrEmpty(word) )
            words.Add(word);
          builder.Clear();
        }
        charLast = charCurrent;
      }
      return words.Count();
    }
