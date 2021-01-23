    public static class BinaryTreeExtensions {
      public static IEnumerable<T> PreorderTraversal<T>(this BinaryTree<T> root) {
        return PreorderTraversalMulti(root).Flatten();
      }
      private static IEnumerable<IEnumerable<T>> PreorderTraversalMulti<T>(
        this BinaryTree<T> root) {
        if (root == null) yield break;
        yield return root.Item.Pack(); // this packs an item into an enumerable
        yield return root.Left.PreorderTraversal();
        yield return root.Right.PreorderTraversal();
      }
    }
