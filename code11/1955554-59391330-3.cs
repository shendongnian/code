    private void metroDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e) 
    {
        
    //IF Statement to see if cell contains anything, if it does then open a new form below...
             if (metroDataGrid1.CurrentCell != null && metroDataGrid1.CurrentCell.Value != null)
             {
                 var cellValue = metroDataGrid1.CurrentCell.Value.ToString();
                 frmUserDiary userdiaryclick = new frmUserDiary(); 
                 userdiaryclick.ShowDialog();
             }
             else   
             { 
                // do something
             }
            
    }
