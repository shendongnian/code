        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count != 0)
            {
                if (e.Node.Checked)
                {
                    CheckAllChildNodes1(e.Node);
                }
                else
                {
                    UncheckChildNodes1(e.Node);
                }
            }
        }
