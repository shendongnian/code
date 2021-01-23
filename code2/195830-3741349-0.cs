    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if ((int)treeView1.SelectedNode.Tag == 1)
      {
        removeToolStripMenuItem.Enabled = true;
      }
      else
      {
        removeToolStripMenuItem.Enabled = false;
      }
    }
