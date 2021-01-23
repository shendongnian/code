        public static IEnumerable<IEnumerable<T>> each_cons<T>(this IEnumerable<T> enumerable, int length)
        {
            for (int i = 0; i < enumerable.Count() - length + 1; i++)
            {
                yield return enumerable.Skip(i).Take(length);
            }
        }
