     /// <summary>
            ///  Create a node sorter that implements the IComparer interface.
           /// </summary>
            public class NodeSorter : IComparer
            {
                // compare between two tree nodes
                public int Compare(object thisObj, object otherObj)
                {
                    TreeNode thisNode = thisObj as TreeNode;
                    TreeNode otherNode = otherObj as TreeNode;
    
                    // Compare the types of the tags, returning the difference.
                    if (thisNode.Tag is  first_type&& otherNode.Tag is another_type)
                        return 1;
                     //alphabetically sorting
                    return thisNode.Text.CompareTo(otherNode.Text);
                }
            } 
