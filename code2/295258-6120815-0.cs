    var dataTable = new DataTable();
    Array.ForEach(
        dataGridView1.Columns.Cast<DataGridViewColumn>().ToArray(), 
        arg => dataTable.Columns.Add(arg.HeaderText, arg.ValueType));
    Array.ForEach(
        dataGridView1.Rows.Cast<DataGridViewRow>().ToArray(), 
        arg => dataTable.Rows.Add(arg.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value)));
    return dataTable;
