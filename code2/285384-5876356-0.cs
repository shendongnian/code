    public static string GetBits(int value) {
      var builder = new StringBuilder();
      for (int i = 0; i < 32; i++) {
        var test = 1 << (31 - i);    
        var isSet = 0 != (test & value);
        builder.Append(isSet ? '1' : '0');
      }
      return builder.ToString();
    }
