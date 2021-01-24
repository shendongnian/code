java
/*
    TreePath = {
        HashSet<TreeNode> path,
        bool IsAdded // set to false even if it's true when an instance is cloned
    }
    Every class (Tree...) define the methods:
        public object Clone()
        public bool Equals(T typedObj)
        public override bool Equals(object obj)
        public override int GetHashCode()
*/
enum TreeBranch
{
    Unknown,
    Left,
    Right
}
class TreeDecomposer {
    public List<TreePath> Possibilities = new List<TreePath>();
    public TreeDecomposer(AbstractTree tree)
    {
        DecomposeTree(null, tree, TreeBranch.Unknown, new TreePath());
        RemoveDuplicatePaths();
    }
    public void DecomposeTree(AbstractTree parentNode, AbstractTree node, TreeBranch branch, TreePath path)
    {
        if (!path.IsAdded)
        {
            Possibilities.Add(path);
            path.IsAdded = true;
        }
        // Recursive browse
        if (node is TreeConnector) {
                TreeConnector treeConnector = (TreeConnector)node;
                if (treeConnector.Connection == "&")
                {
                    DecomposeTree(treeConnector, treeConnector.LeftTree, TreeBranch.Left, path);
                    DecomposeTree(treeConnector, treeConnector.RightTree, TreeBranch.Right, path);
                }
                else if (treeConnector.Connection == "|")
                {
                    // In this case, parentNode is a TreeOperator
                    if (parentNode != null)
                    {
                        // Left distribution
                        TreePath clonedPathLeftDistribution = (TreePath)path.Clone();
                        TreeConnector parentTreeConnectorLeftDistribution = (TreeConnector)parentNode.Clone();
                        // Right distribution
                        TreePath clonedPathRightDistribution = (TreePath)path.Clone();
                        TreeConnector parentTreeConnectorRightDistribution = (TreeConnector)parentNode.Clone();
                        if (branch == TreeBranch.Left)
                        {
                            parentTreeConnectorLeftDistribution.LeftTree = treeConnector.LeftTree;
                            parentTreeConnectorRightDistribution.LeftTree = treeConnector.RightTree;
                        }
                        else if (branch == TreeBranch.Right)
                        {
                            parentTreeConnectorLeftDistribution.RightTree = treeConnector.LeftTree;
                            parentTreeConnectorRightDistribution.RightTree = treeConnector.RightTree;
                        }
                        // Remove obsolete path
                        Possibilities.Remove(path);
                        // Browse recursively distributed tree ; the path must be different (by ref) if the parent operator is 'OR'
                        DecomposeTree(
                            parentTreeConnectorLeftDistribution,
                            parentTreeConnectorLeftDistribution.LeftTree,
                            TreeBranch.Left,
                            parentTreeConnectorLeftDistribution.Connection == "|"
                                ? (TreePath)clonedPathLeftDistribution.Clone()
                                : clonedPathLeftDistribution
                        );
                        DecomposeTree(
                            parentTreeConnectorLeftDistribution,
                            parentTreeConnectorLeftDistribution.RightTree,
                            TreeBranch.Right,
                            clonedPathLeftDistribution
                        );
                        DecomposeTree(
                            parentTreeConnectorRightDistribution,
                            parentTreeConnectorRightDistribution.LeftTree,
                            TreeBranch.Left,
                            parentTreeConnectorLeftDistribution.Connection == "|"
                                ? (TreePath)clonedPathRightDistribution.Clone()
                                : clonedPathRightDistribution
                        );
                        DecomposeTree(
                            parentTreeConnectorRightDistribution,
                            parentTreeConnectorRightDistribution.RightTree,
                            TreeBranch.Right,
                            clonedPathRightDistribution
                        );
                    }
                    // The operator is the root of the tree; we simply divide the path
                    else
                    {
                        TreePath clonedLeftPath = (TreePath)path.Clone();
                        TreePath clonedRightPath = (TreePath)path.Clone();
                        // Remove obsolete path
                        Possibilities.Remove(path);
                        DecomposeTree(treeConnector, treeConnector.LeftTree, TreeBranch.Left, clonedLeftPath);
                        DecomposeTree(treeConnector, treeConnector.RightTree, TreeBranch.Right, clonedRightPath);
                    }
                }
                break;
        }
        // Leaf
        else if (node is TreeValue) {
            TreeValue treeValue = (TreeValue)node;
            path.Add(treeValue);
        }
    }
    public void RemoveDuplicatePaths()
    {
        Possibilities = Possibilities.Distinct().ToList();
    }
}
<br/>
**Note:**
Here, I want to keep only the unique possibilities; that's why I use HashSet<T> instead of List<T>:
 - "a & a & b" => "a & b"
The method RemoveDuplicatePaths is used to remove duplicated combinations: 
 - "a & b" and "b & a" are both the same possibility (regarding the truth value)
