    public class IteratedNode<T>
    {
        public T Node;
        public T ParentNode;
        public int Level;
        public int Index;
    }
    /// <summary>
    /// Iterates over a tree/graph via In Order Breadth First search.
    /// </summary>
    /// <param name="root">The root item.</param>
    /// <param name="childSelector">A func that receives a node in the tree and returns its children.</param>
    public static IEnumerable<IteratedNode<T>> GetBreadthFirstEnumerable<T>(this T root, Func<T, IEnumerable<T>> childSelector)
    {
        var rootNode = new IteratedNode<T> { Node = root, ParentNode = default(T), Level = 1, Index = 1};
        var nodesToProcess = new Queue<IteratedNode<T>>( new[] {rootNode});
        int itemsIterated = 0;
        while (nodesToProcess.Count > 0)
        {
            IteratedNode<T> currentItem = nodesToProcess.Dequeue();
            yield return currentItem; itemsIterated++;
            // Iterate over the children of this node, and add it to queue, to process later.
            foreach (T child in childSelector(currentItem.Node))
            {
                nodesToProcess.Enqueue( 
                    new IteratedNode<T> {
                        Node = child,
                        ParentNode = currentItem.Node,
                        Level = currentItem.Level + 1,
                        Index = itemsIterated
                    });                      
            }
        }
    }
