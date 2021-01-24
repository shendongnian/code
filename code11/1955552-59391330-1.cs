    private void metroDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e) 
    {
        
    //IF Statement to see if cell contains anything, if it does then open a new form below...
             if (metroDataGrid1.CurrentCell != null && !string.IsNullOrEmpty(metroDataGrid1.CurrentCell.Value))
             {
                 frmUserDiary userdiaryclick = new frmUserDiary(); 
                 userdiaryclick.ShowDialog();
             }
             else   
             { 
                // do something
             }
            
    }
