        public static IEnumerable<T> Traverse<T>(this T e, Func<T, IEnumerable<T>> childrenProvider)
        {
            return TraverseMany(new[] { e }, childrenProvider);
        }
        public static IEnumerable<T> TraverseMany<T>(this IEnumerable<T> collection, Func<T, IEnumerable<T>> childrenProvider)
        {
            var stack = new Stack<T>();
            foreach(var c in collection)
            {
                stack.Push(c);
            }
            while (stack.Count > 0)
            {
                var i = stack.Pop();
                yield return i;
                var children = childrenProvider(i);
                if (children != null)
                {
                    foreach (var c in children)
                    {
                        stack.Push(c);
                    }
                }
            }
        }
