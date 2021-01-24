//Update Button
TableCell cell7 = new TableCell();
Button btn1 = new Button();
btn.Id="btnUpdate";
btn.Text = "Update";
btn.Click += new EventHandler(btnUpdate_Click);
cell7.Controls.Add(btn1);
//Delete Button
TableCell cell8 = new TableCell();
Button btn2 = new Button();
btn.Id="btnDelete";
btn.Text = "Delete";
btn.Click += new EventHandler(btnDelete_Click);
cell8.Controls.Add(btn2);
// add above two cell objects to row object
 row.Cells.Add(cell7);
 row.Cells.Add(cell8); 
//Update button event handler
protected void btnUpdate_Click(object sender,EventArgs e)
{
    // update the record
}
//Delete button event handler
protected void btnDelete_Click(object sender,EventArgs e)
{
    // Delete the record
}
