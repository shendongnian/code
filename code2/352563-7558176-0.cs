    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Visit each node, then visit any child-list(s) the node maintains
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subjects">IEnumerable to traverse/></param>
        /// <param name="getChildren">Delegate to get T's direct children</param>
        public static IEnumerable<T> PreOrder<T>(this IEnumerable<T> subjects, Func<T,    IEnumerable<T>> getChildren)
        {
            if (subjects == null)
                yield break;
            // Would a DQueue work better here?
            // A stack could work but we'd have to REVERSE the order of the subjects and children
            var stillToProcess = subjects.ToList();
            while (stillToProcess.Any())
            {
                // First, visit the node
                T item = stillToProcess[0];
                stillToProcess.RemoveAt(0);
                yield return item;
                // Queue up any children
                if (null != getChildren)
                {
                    var children = getChildren(item);
                    if (null != children)
                        stillToProcess.InsertRange(0, children);
                }
            }
        }
    }
