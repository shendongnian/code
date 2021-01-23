        public static class IsEmptyInRangeExtension
        {
            public static bool IsEmptyInRange(this IEnumerable<string> strings, int startIndex, int endIndex)
            {
                return strings.Skip(startIndex).TakeWhile((x, index) => string.IsNullOrEmpty(x) && index <= endIndex).Count() > 0;
            }
      
        }
