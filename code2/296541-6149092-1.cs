    private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck)
            {
                foreach (TreeNode trNode in trNodeCollection)
                {
                    trNode.Checked = isCheck;
                    if (trNode.Nodes.Count > 0)
                        CheckUncheckTreeNode(trNode.Nodes, isCheck);
                }
            }
