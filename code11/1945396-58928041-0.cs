csharp
public static class Extensions
{
    public static TreeNode ToTreeNode(this BinaryTreeNode binary)
    {
        var treeNode = new TreeNode(binary.Key);
        treeNode.left = binary.Left?.ToTreeNode();
        treeNode.right = binary.right?.ToTreeNode();
    }
}
