    public static class StringBuilderExtensions {
    
      public static StringBuilder AppendAll(this StringBuilder builder, IEnumerable<string> strings) {
        foreach (string s in strings) builder.Append(s);
        return builder;
      }
    
    }
