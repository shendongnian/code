    using System.Collections.Generic;
    using System.Windows.Forms;
    public static class TreeNodeCollectionExtensions
    {
        public static IEnumerable<TreeNode> AsEnumerable(this TreeNodeCollection nodes)
        {
            foreach (TreeNode c1 in nodes)
            {
                yield return c1;
                foreach (TreeNode c2 in AsEnumerable(c1.Nodes))
                    yield return c2;
            }
        }
    }
