    public static class ObjectExtensions
    {
      public static string SafelyToString(this object o)
      {
         return o != null ? o.ToString() : string.Empty;
      }
    }
