    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
      Console.WriteLine(e.Node.Text);
    }
    private void button1_Click(object sender, EventArgs e) {
      Console.WriteLine(treeView1.SelectedNode.Text);
    }
