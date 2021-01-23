    void DataGridView1_OnCellClick(object sender, DataGridViewCellEventArgs e)
    {
        int rowClicked = e.RowIndex;
        int columnClicked = e.ColumnIndex;
        
        ///If the column clicked was the one that has the long texts, 
        //just find the original text in 'texts' using 'rowClicked' and show the 
        //message using MessageBox or creating a new Form for that purpose and 
        //showing it using ShowDialog()
    }
