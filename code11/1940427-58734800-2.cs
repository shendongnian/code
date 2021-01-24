    static public Dictionary<string, int> CountDistinctWords(this string text)
    {
      string str = text.Replace(Environment.NewLine, " ");
      var builder = new StringBuilder();
      char charLast = ' ';
      char charCurrent;
      var words = new Dictionary<string, int>();
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
          if ( !words.ContainsKey(word) && !string.IsNullOrEmpty(word) )
            words.Add(word, 1);
          else
            words[word]++;
          builder.Clear();
        }
        charLast = charCurrent;
      }
      return words;
    }
