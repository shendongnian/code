        public static IEnumerable<T> Last<T>(this IEnumerable<T> enumerable, int nLastElements)
        {
            int count = Math.Min(enumerable.Count(), nLastElements);
            for (int i = enumerable.Count() - count; i < enumerable.Count(); i++)
            {
                yield return enumerable.ElementAt(i);
            }
        }
