        public static IEnumerable<Node> DepthFirstUnfold(this Node root) =>
            ObjectAsEnumerable(root).Concat(root.Children.SelectMany(DepthFirstUnfold));
        public static IEnumerable<Node> BreadthFirstUnfold(this Node root) {
            var queue = new Queue<IEnumerable<Node>>();
            queue.Enqueue(ObjectAsEnumerable(root));
            while (queue.Count != 0)
                foreach (var node in queue.Dequeue()) {
                    yield return node;
                    queue.Enqueue(node.Children);
                }
        }
        private static IEnumerable<T> ObjectAsEnumerable<T>(T obj) {
            yield return obj;
        }
