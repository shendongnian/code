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
if it is important that you can just use `C# 4.0` you would have to write it like this:
csharp
public static class Extensions
{
    public static TreeNode ToTreeNode(this BinaryTreeNode binary)
    {
        var treeNode = new TreeNode(binary.Key);
        if (binary.Left != null)
            treeNode.left = binary.Left.ToTreeNode();
        if (binary.Right != null)
            treeNode.right = binary.right.ToTreeNode();
    }
}
