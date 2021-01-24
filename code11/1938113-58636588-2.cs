    checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
    public void checkBox1_CheckedChanged(Object sender, EventArgs e) 
    {
        dataGridView1.Columns["nameOfColumnThatShouldBeInvisible"].Visible = checkBox1.Checked;
        //rebind dataGridView1 so as to show/hide column for clicked checkbox
    }
