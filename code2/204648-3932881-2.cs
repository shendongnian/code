    public static class IntegerExtensions
    {
      public static void TimesWithIndex(this int count, Action<int> action)
      {
         for (int i = 0; i < count; i++)
            action(i);
      }
    }
