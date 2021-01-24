    static public class StringHelper
    {
      static public bool ContainsOnlyChars(this string strValue, params char[] charValues)
      {
        if ( string.IsNullOrEmpty(strValue) )
          throw new ArgumentNullException("String cannot be null or empty.");
        if ( charValues == null )
          throw new ArgumentNullException("Chars cannot be null.");
      for ( int index = 0; index < strValue.Length; index++ )
        if ( !charValues.Contains(strValue[index]) )
            return false;
        return true;
      }
    }
