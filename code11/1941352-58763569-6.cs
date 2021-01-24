    using System.Text;
    static public string ToStringFormatted(this IDictionary dictionary, char separator = ';')
    {
      var builder = new StringBuilder();
      foreach ( DictionaryEntry item in dictionary )
        builder.Append($"{item.Key.ToString()}={item.Value.ToString()}{separator}");
      return builder.ToString().TrimEnd(separator);
    }
