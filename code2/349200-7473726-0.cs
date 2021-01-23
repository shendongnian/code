        private void SortButton_Click(object sender, EventArgs e) {
            if (treeView1.TreeViewNodeSorter == null) {
                treeView1.TreeViewNodeSorter = new NodeSorter();
            }
        }
        private class NodeSorter : System.Collections.IComparer {
            public int Compare(object x, object y) {
                TreeNode node1 = (TreeNode)x;
                TreeNode node2 = (TreeNode)y;
                if (node1.Level == 1) {
                    return Convert.ToInt32(node1.Tag).CompareTo(Convert.ToInt32(node2.Tag));
                }
                else {
                    return node1.Index.CompareTo(node2.Index);
                }
            }
        }
