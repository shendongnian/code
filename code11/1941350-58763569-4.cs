    using System.Collections;
    static public class IDictionaryHelper
    {
      static public string ToStringFormatted(this IDictionary dictionary,
                                             char separator = ';')
      {
        string result = "";
        foreach (DictionaryEntry item in dictionary)
        result += $"{item.Key.ToString()}={item.Value.ToString()}{separator}";
        return result.TrimEnd(separator);
      }
    }
