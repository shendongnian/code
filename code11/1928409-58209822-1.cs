    static public class StringHelper
    {
      static public string CapitalizeFirstLetterOfWords(this string str)
      {
        if ( str == null ) return null;
        var words = str.Split(' ');
        for ( int i = 0; i < words.Length; i++ )
          if ( words[i] != "" )
          {
            char c = char.ToLower(words[i][words[i].Length - 1]);
            words[i] = words[i].Substring(0, words[i].Length - 1) + c;
          }
        str = "";
        foreach ( string word in words )
        {
          if ( str != "" ) str += " ";
          str += word;
        }
        return str;
      }
    }
