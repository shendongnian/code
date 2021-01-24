    static public string ToHex(byte[] array)
    {
      var builder = new StringBuilder();
      for ( int index = array.Length - 1; index >= 0; index-- )
      {
        builder.Append($"{array[i]:X2} ");
      }
      return builder.ToString().TrimEnd();
    }
