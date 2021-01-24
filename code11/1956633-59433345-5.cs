    public static class Extensions
    {
      public static bool Contains(this string source, string searchTerm, StringComparison comparison)
      {
        return searchTerm != null && source?.IndexOf(searchTerm, comparison) >= 0;
      }
    }
