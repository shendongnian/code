    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
       if (dataGridView1.CurrentCell.ColumnIndex == 0)
       {
          TextBox tb = (TextBox)e.Control;
          tb.TextChanged += new EventHandler(tb_TextChanged);
       }
    }
    void tb_TextChanged(object sender, EventArgs 
    {
       MessageBox.Show("changed");
    }
