    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (Convert.ToInt16(e.Node.Tag) == 1)
            {
                childToolStripMenuItem.Enabled = false;
                rootToolStripMenuItem.Enabled = true;
            }
            if (Convert.ToInt16(e.Node.Tag) == 2)
            {
                childToolStripMenuItem.Enabled = true;
                rootToolStripMenuItem.Enabled = false;
            }
        }
