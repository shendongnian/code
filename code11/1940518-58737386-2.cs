    static public string ToHex(byte[] array)
    {
      var builder = new StringBuilder();
      array = array.Reverse().ToArray();
      for ( int index = 0; index < array.Length; index++ )
      {
        builder.Append($"{array[i]:X2} ");
      }
      return builder.ToString().TrimEnd();
    }
