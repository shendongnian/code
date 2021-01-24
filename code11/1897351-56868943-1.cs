var flat = root.data.SelectMany(x => x.SelectChilds(y => y.children));
Extension method to help create the flat structure:
    public static class Extensions
    {
        /// <summary>
        /// Recursive method to return a flat structure of child elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func">Function to get child elements</param>
        /// <returns></returns>
        public static IEnumerable<T> SelectChilds<T>(this T source, Func<T, IEnumerable<T>> func)
        {
            yield return source;
            foreach (T element in func(source) ?? Enumerable.Empty<T>())
            {
                var subs = element.SelectChilds(func);
                foreach (T sub in subs)
                {
                    yield return sub;
                }
            }
        }
    }
