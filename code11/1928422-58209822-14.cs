    using System.Linq;
    static public string LastLetterOfWordsToLower(this string str)
    {
      if ( str == null ) return null;
      var words = str.Split(' ');
      for ( int indexWord = 0; indexWord < words.Length; indexWord++ )
      {
        string word = words[indexWord];
        if ( word != "" )
        {
          for ( int indexChar = word.Length - 1; indexChar >= 0; indexChar-- )
            if ( char.IsLetter(word[indexChar]) )
            {
              char c = char.ToLower(word[indexChar]);
              words[indexWord] = word.Substring(0, indexChar) + c;
              if ( indexChar != word.Length - 1 )
                words[indexWord] += word.Substring(indexChar + 1);
              break;
            }
        }
      }
      str = "";
      foreach ( string word in words )
      {
        if ( str != "" ) str += " ";
        str += word;
      }
      return str;
    }
    static public string FirstLetterOfWordsToLower(this string str)
    {
      if ( str == null ) return null;
      var words = str.Split(' ');
      for ( int indexWord = 0; indexWord < words.Length; indexWord++ )
      {
        string word = words[indexWord];
        if ( word != "" )
        {
          for ( int indexChar = 0; indexChar < word.Length; indexChar++ )
            if ( char.IsLetter(word[indexChar]) )
            {
              char c = char.ToLower(word[indexChar]);
              words[indexWord] = c + word.Substring(indexChar + 1);
              if ( indexChar != 0 )
                words[indexWord] = word.Substring(0, indexChar) + words[indexWord];
              break;
            }
        }
      }
      str = "";
      foreach ( string word in words )
      {
        if ( str != "" ) str += " ";
        str += word;
      }
      return str;
    }
