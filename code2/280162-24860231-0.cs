            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;
                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
            if (isChecked && node.Parent != null)
            {
                treeView1.AfterCheck -= HandleOnTreeViewAfterCheck;
                node.Parent.Checked = true;
                treeView1.AfterCheck += HandleOnTreeViewAfterCheck;
            }
            if (!isChecked && node.Parent != null)
            {
                bool unchk = true;
                treeView1.AfterCheck -= HandleOnTreeViewAfterCheck;
                foreach (TreeNode item in node.Parent.Nodes)
                {
                    if (item.Checked)
                    {
                        unchk = false;
                        break;
                    }
                }
                if (unchk)
                    node.Parent.Checked = false;
                treeView1.AfterCheck += HandleOnTreeViewAfterCheck;
            }
        }
