    public class NodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;
    
            // Your sorting logic here... return -1 if tx < ty, 1 if tx > ty, 0 otherwise
            ...
        }
    }
