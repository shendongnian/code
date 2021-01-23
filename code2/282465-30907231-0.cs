        /// <summary>
        /// Depth first search implementation in c#
        /// </summary>
        /// <typeparam name="T">Type of tree structure item</typeparam>
        /// <typeparam name="TChilds">Type of childs collection</typeparam>
        /// <param name="node">Starting node to search</param>
        /// <param name="ChildsProperty">Property to return child node</param>
        /// <param name="Match">Predicate for matching</param>
        /// <returns>The instance of matched result, null if not found</returns>
        public static T DepthFirstSearch<T, TChilds>(this T node, Func<T, TChilds> ChildsProperty, Predicate<T> Match) 
            where T:class
        {
            if (!(ChildsProperty(node) is IEnumerable<T>))
                throw new ArgumentException("ChildsProperty must be IEnumerable<T>");
            Stack<T> stack = new Stack<T>();
            stack.Push(node);
            while (stack.Count > 0) {
                T thisNode = stack.Pop();
                #if DEBUG
                System.Diagnostics.Debug.WriteLine(thisNode.ToString());
                #endif
                if (Match(thisNode))
                    return thisNode;
                if (ChildsProperty(thisNode) != null) {
                    foreach (T child in (ChildsProperty(thisNode) as IEnumerable<T>).Reverse()) 
                        stack.Push(child);
                }
            }
            return null;
        }
