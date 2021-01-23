    public static string MaskValue(string mask, string value) {
      var builder = new System.Text.StringBuilder();
      var maskIndex = 0;
      var valueIndex = 0;
      while (maskIndex < mask.Length && valueIndex < value.Length) {
        if (mask[maskIndex] == '-') {
          builder.Append('-');
          maskIndex++;
        } else {
          builder.Append(value[valueIndex]);
          maskIndex++;
          valueIndex++;
        }
      }
      // Add in the remainder of the value
      if (valueIndex + 1 < value.Length) {
        builder.Append(value.Substring(valueIndex);
      }
      return builder.ToString();
    }
