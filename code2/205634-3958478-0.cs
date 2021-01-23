    private void DataGridView1_OnCellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    
       if (e.ColumnIndex == 0 && e.RowIndex > -1) // Replace 0 with the checkbox col index
       {
             if ((bool)this.DataGridView1[e.ColumnIndex, e.RowIndex].Value == true)
             {
                 // Checkbox is checked so call you command
             }
       }
    
    }
