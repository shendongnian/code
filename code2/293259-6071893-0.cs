    public static class StringExt
    {
      public static String FixNewLines(this String str)
      {
        return str.Replace(@'\n',Environment.NewLine);
      }
    }
