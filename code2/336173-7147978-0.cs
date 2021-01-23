    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // Here you get the row that you want to edit.
       GridViewRow row = GridView1.Rows[e.RowIndex];
       // This one returns you the cell inside the row that is being edited.
       // Replace 1 with the column no you want.
       TableCell tableCell = row .Controls[1] as TableCell;
       // And finally you have your textbox.
       TextBox textBox = tableCell.Controls[0] as TextBox;        
    }
