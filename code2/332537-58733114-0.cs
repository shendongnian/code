    public static class TypeExtentions
    {
        public static IEnumerable<T> Descendants<T>(this T root, Func<T, IEnumerable<T>> selector)
        {
            var nodes = new Stack<T>(new[] { root });
            while (nodes.Any())
            {
                T node = nodes.Pop();
                yield return node;
                foreach (var n in selector(node)) nodes.Push(n);
            }
        }
        public static IEnumerable<T> Descendants<T>(this IEnumerable<T> encounter, Func<T, IEnumerable<T>> selector)
        {
            var nodes = new Stack<T>(encounter);
            while (nodes.Any())
            {
                T node = nodes.Pop();
                yield return node;
                if (selector(node) != null)
                    foreach (var n in selector(node))
                        nodes.Push(n);
            }
        }
    }
