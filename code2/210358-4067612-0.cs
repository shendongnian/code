    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Compare the column to the column you want to format
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "ColumnName")
        {
            //get the IChessitem you are currently binding, using the index of the current row to access the datasource
            IChessItem item = sourceList[e.RowIndex];
            //check the condition
            if (item == condition)
            {
                 e.CellStyle.BackColor = Color.Green;
            }
        }
    }
    
