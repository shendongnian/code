    static public class StringHelper
    {
      static public int CountWords(this string text)
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
            words.Add(builder.ToString());
            builder.Clear();
          }
          charLast = charCurrent;
        }
        return words.Where(item => !string.IsNullOrEmpty(item)).Count();
      }
    }
