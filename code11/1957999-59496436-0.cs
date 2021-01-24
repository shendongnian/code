     private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
                string selectedNodeText = e.Node.Text;
                MessageBox.Show(selectedNodeText);
            }
