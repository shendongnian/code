    static public class IDictionaryHelper
    {
      static public string ToStringFormatted(this IDictionary dictionary,
                                             char separator = ";")
      {
        var keys = dictionary.Keys;
        var values = dictionary.Values;
        var listKeys = new List<object>();
        var listValues = new List<object>();
        foreach ( var item in keys )
          listKeys.Add(item);
        foreach ( var item in values )
          listValues.Add(item);
        string result = "";
        for ( int index = 0; index < listKeys.Count; index++ )
          result += $"{listKeys[index].ToString()}=" + 
                    $"{listValues[index].ToString()}{separator}";
        return result.TrimEnd(separator);
      }
    }
