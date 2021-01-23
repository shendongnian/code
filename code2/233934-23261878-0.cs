    private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)  
    {
            SendKeys.Send("{UP}");
            SendKeys.Send("{Right}");
    }
    
    private void onEnterKeyPress(object sender, KeyPressEventArgs e)
    {
    
          if (sender is DataGridView)
          {
             int iColumn = DataGridView1.CurrentCell.ColumnIndex;
             if (iColumn == DataGridView1.Columns.Count - 1)
             {
                   SendKeys.Send("{home}");
             }
             else
             {
             
                   this.ProcessTabKey(true);
             }
           }
    }
