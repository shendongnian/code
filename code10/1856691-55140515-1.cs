    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)  //<= Specify your data grid view combo box column index instead of 1
        {
            ComboBox comboBox = e.Control as ComboBox;
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.DrawItem -= ComboBox_DrawItem;
            comboBox.DrawItem += ComboBox_DrawItem;
        }
    }
    
