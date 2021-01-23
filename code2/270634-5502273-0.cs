    TreeView treeView1;
    void Initialize_It() {
      treeView1 = new TreeView();
      treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
      TreeNode Root = treeView1.Nodes.Add("ROOT");
      TreeNode Child = Root.Nodes.Add("CHILD");
      TreeNode SubChild = Child.Nodes.Add("Sub-Child");
    }
    void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
      const string FORMAT = "{0} Node Selected. Call your Windows Form from here.";
      if (e.Node.Level == 0) {
        MessageBox.Show(string.Format(FORMAT, e.Node.Text), e.Node.Text);
      } else if (e.Node.Level == 1) {
        MessageBox.Show(string.Format(FORMAT, e.Node.Text), e.Node.Text);
      } else if (e.Node.Level == 2) {
        MessageBox.Show(string.Format(FORMAT, e.Node.Text), e.Node.Text);
      }
    }
