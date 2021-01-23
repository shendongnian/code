    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      TreeView tv = GetSourceControl(sender) as TreeView;
      if (tv != null)
      {
        tv.Nodes.Add("Tree event catched!");
      }
    }
