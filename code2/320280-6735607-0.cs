    public static class XElementExtensions
    {
      public static string TrimmedValue(this XElement elem)
      {
         if(elem == null)
            return null;
         if(String.IsNullOrEmpty(elem.Value))
            return elem.Value
         return elem.Value.Trim();
      }
    }
