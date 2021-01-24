    public static partial class JsonExtensions
    {
        /// <summary>
        /// Enumerates through all descendants of the given element, returning the topmost elements that match the given predicate
        /// </summary>
        /// <param name="root"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<TJToken> TopDescendantsWhere<TJToken>(this JToken root, Func<TJToken, bool> predicate) where TJToken : JToken
        {
            if (predicate == null)
                throw new ArgumentNullException();
            return GetTopDescendantsWhere<TJToken>(root, predicate, false);
        }
        static IEnumerable<TJToken> GetTopDescendantsWhere<TJToken>(JToken root, Func<TJToken, bool> predicate, bool includeSelf) where TJToken : JToken
        {
            if (root == null)
                yield break;
            if (includeSelf)
            {
                var currentOfType = root as TJToken;
                if (currentOfType != null && predicate(currentOfType))
                {
                    yield return currentOfType;
                    yield break;
                }
            }
            var rootContainer = root as JContainer;
            if (rootContainer == null)
                yield break;
            var current = root.First;
            while (current != null)
            {
                var currentOfType = current as TJToken;
                var isMatch = currentOfType != null && predicate(currentOfType);
                if (isMatch)
                    yield return currentOfType;
                // If a match, skip children, but if not, advance to the first child of the current element.
                var next = (isMatch ? null : current.FirstChild());
                if (next == null)
                    // If no first child, get the next sibling of the current element.
                    next = current.Next;
                // If no more siblings, crawl up the list of parents until hitting the root, getting the next sibling of the lowest parent that has more siblings.
                if (next == null)
                {
                    for (var parent = current.Parent; parent != null && parent != root && next == null; parent = parent.Parent)
                    {
                        next = parent.Next;
                    }
                }
                current = next;
            }
        }
        static JToken FirstChild(this JToken token)
        {
            var container = token as JContainer;
            return container == null ? null : container.First;
        }
    }
