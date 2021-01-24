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
###Update 1
If you really want to use casting you could implement the `explicit operator` functionality of C#. (I don´t know if the wording is correct. :D)
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
    public static explicit operator TreeNode(BinaryTreeNode b)
    {
        return b.ToTreeNode();
    }
}
But there are several drawbacks when taking that approach:  
- It´s much cleaner to use `node.ToTreeNode()` over `(TreeNode)node`.  
- Navigating through code is harder.  
- You have to edit the existing `TreeNode` class. So you break the `Open-Close Principle`.  
