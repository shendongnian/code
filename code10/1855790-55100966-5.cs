    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        //if click is on row header or column header, do nothing.
        if(e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
    
        //Check if click is on specific column 
        if( e.ColumnIndex  == dataGridView1.Columns["specific column name"].Index)
        {
            //Put some logic here, for example show a dialog and use result.
        }
    }
