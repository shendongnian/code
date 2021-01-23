    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
           if (treeView1.SelectedNode.Level == 0)
              {
                  HeadForm hf = new HeadForm();
                  hf.ShowDialog(); 
              }
           else if (treeView1.SelectedNode.Level == 1)
              {
                  MemberForm mf = new MemberForm();
                  mf.ShowDialog(); 
              }
           else if (treeView1.SelectedNode.Level == 2)
              {
                  SubMemberForm sf = new SubMemberForm();
                  sf.ShowDialog(); 
              }
    }
