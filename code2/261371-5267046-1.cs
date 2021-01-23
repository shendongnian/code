    private void ContextMenu_onClick(object sender, EventArgs e)
    {
        var clicked = sender as MenuItem;
        if (clicked != null)
        {
            // Update the state of the context menu
            clicked.Checked = !clicked.Checked;
            // Update the visibity of this column
            this.dataGridView.Columns[clicked.Text].Visible = clicked.Checked;
        }
    }
