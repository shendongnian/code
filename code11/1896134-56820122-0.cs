    public static string Join<T>(this IReadOnlyCollection<T> me,
      string separator, int startIndex = 0, int endIndexInclusive = -1)
    {
      if (endIndexInclusive < 0)
        endIndexInclusive += me.Count;
      var range = me.Skip(startIndex).Take(endIndexInclusive - startIndex + 1);
      return string.Join(separator, range);
    }
