`
    using System.Linq;
`
`
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
`
`
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
`
The test:
`
    static public void StringHelperTest()
    {
      string str1 = null;
      string str2 = "";
      string str3 = "A";
      string str4 = "TEST";
      string str5 = "A TEST STRING, FOR  STACK OVERFLOW!!";
      Console.WriteLine(str1.LastLetterOfWordsToLower());
      Console.WriteLine(str2.LastLetterOfWordsToLower());
      Console.WriteLine(str3.LastLetterOfWordsToLower());
      Console.WriteLine(str4.LastLetterOfWordsToLower());
      Console.WriteLine(str5.LastLetterOfWordsToLower());
      Console.WriteLine(str1.FirstLetterOfWordsToLower());
      Console.WriteLine(str2.FirstLetterOfWordsToLower());
      Console.WriteLine(str3.FirstLetterOfWordsToLower());
      Console.WriteLine(str4.FirstLetterOfWordsToLower());
      Console.WriteLine(str5.FirstLetterOfWordsToLower());
    }
`
The output:
`
a
TESt
A TESt STRINg, FOr  STACk OVERFLOw!!
a
tEST
a tEST sTRING, fOR  sTACK oVERFLOW!!
`
StringBuilder can be used for performance issues.
