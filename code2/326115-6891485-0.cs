    //to copy the rows you need to have created the columns:
    foreach (DataGridViewColumn c in dataGridView1.Columns)
    {                
        dataGridView2.Columns.Add(c.Clone() as DataGridViewColumn);
    }
    //then you can copy the rows values one by one (working on the selectedrows collection)
    foreach (DataGridViewRow r in dataGridView1.SelectedRows)
    {
        int index = dataGridView2.Rows.Add(r.Clone() as DataGridViewRow);
        foreach (DataGridViewCell o in r.Cells)
        {
            dataGridView2.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
        }            
    }
