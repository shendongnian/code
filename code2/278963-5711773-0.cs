    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        //if checkbox is unchecked
        if (!CheckBox1.Checked)
        {
            //uncheck all checkboxes of tree view
            foreach (TreeNode node in TreeView.Nodes)
            {
                node.Checked = false;
            }
        }
    }
