lang-csharp
private void PopulateDataGridView()
{
   // Assuming I have a DataGridView named dataGridView1 with only one column
   // which is a DataGridViewButtonColumn named ButtonColumn that I set up in
   // the "Add Columns" or "Edit Columns" window...
   var row = new DataGridViewRow();
   var btnCell = new DataGridViewButtonCell();
   
   // Instead of btnCell.UseColumnTextForButtonValue = true, do this to set the
   // text of the button to the text of the column by default.
   btnCell.Value = ButtonColumn.Text;
   row.Cells.Add(btnCell);   
   dataGridView1.Rows.Add(row);
}
private void dataGridView1_CellContentClick(
   object sender, 
   DataGridViewCellEventArgs e)
{
   dataGridView1[e.ColumnIndex, e.RowIndex].Value = "Loading...";
}
