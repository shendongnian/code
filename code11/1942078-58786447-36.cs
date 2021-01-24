    static public class StringHelper
    {
      static public bool ContainsOnlyChars(this string strValue, params char[] charValues)
      {
        if ( string.IsNullOrEmpty(strValue) )
          throw new ArgumentNullException("String cannot be null or empty.");
        if ( charValues == null )
          throw new ArgumentNullException("Chars cannot be null.");
        for ( int index = 0; index < charValues.Length; index++ )
          if ( strValue.IndexOf(charValues[index]) == -1 )
            return false;
        return true;
      }
    }
