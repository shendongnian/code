        public static IEnumerable<T> SkipExceptions<T>(
            this IEnumerable<T> values)
        {
            var enumerator = values.GetEnumerator();
            bool next = true;
            while (next)
            {
                try
                {
                    next = enumerator.MoveNext();
                }
                catch
                {
                    continue;
                }
                if(next) yield return enumerator.Current;
            }
        }
