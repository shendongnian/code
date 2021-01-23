    public static class StringExtensions
    {
        public static string Join<T>(this string joinWith, IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (joinWith == null)
                throw new ArgumentNullException("joinWith");
            var stringBuilder = new StringBuilder();
            var enumerator = list.GetEnumerator();
            if (!enumerator.MoveNext())
                return string.Empty;
            while (true)
            {
                stringBuilder.Append(enumerator.Current);
                if (!enumerator.MoveNext())
                    break;
                stringBuilder.Append(joinWith);
            }
            return stringBuilder.ToString();
        }
    }
