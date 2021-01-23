    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
       string cellVal = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
       if (String.IsNullOrEmpty(listGridVals.Find(delegate(string s) { return s == cellVal; })))
           listGridVals.Add(cellVal);
       else
           MessageBox.Show("Value: " + cellVal + " already in the grid!");
    
    }
