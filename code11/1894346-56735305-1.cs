        private void findButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(keyTextBox.Text.Trim()))
            {
                var result = Find(treeView1.Nodes, keyTextBox.Text.Trim());
                if (result != null)
                {
                    treeView1.SelectedNode = result;
                    treeView1.Focus();
                }
            }
        }
