    StringBuilder sb = new StringBuilder();
    for(int row=0; row<DataGridView.Rows.Count; row++)
    {
        for(int col=0; col < DataGridView.Columns.Count; col++)
        {
            sb.Append(DataGridView.Row[row][col].ToString());
        }
    }
    sb.ToString(); // that will give you the string you desire
    
