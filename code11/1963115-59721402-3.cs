private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
    try {
        string nd = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        System.Diagnostics.Debug.WriteLine("Cell seleccionada: " + nd + " current row es: " + e.RowIndex);
        string nOrdFab = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["ggConnectionString"].ToString());
        String strSql = "";
        SqlCommand comando;
        SqlDataAdapter adapter;
    } catch (Exception ex)
    {
        MessageBox.Show(Form.ActiveForm, "Error: " + ex.ToString());
    }
}
It would also be beneficial to remove the Try Catch once you have this code fully operational - or at least only catch external errors thrown from the SqlAdapter. Also, if your columns are created in the designer, then your form will have a field for each column - such as `IDDataGridViewTextboxColumn` - which you can access the index of like `IDDataGridViewTextboxColumn.Index` to simplify and clarify which column you are accessing. This would make the declaration of nOrdFab much more clear; for example:
    string nOrdFab = dataGridView1.Rows[e.RowIndex].Cells[IDDataGridViewTextboxColumn.Index].Value.ToString();
**EDIT:** If you're trying to do the work in a `ContextMenuStrip` event handler, then you still need to handle the `CellClick` event to set the current cell's selection to the one that was right clicked, but will need to use the `CurrentCell` property again in the event handler for the `ToolStripMenuItem's` `Click` event.
The CellClick Handler:
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
    if (e.Button == MouseButtons.Right && e.RowIndex >= 0) {
        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    }
}
Then the context menu item handler:
private void abrirIncendia_Click(object sender, EventArgs e) {
    try {
        string nOrdFab = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
        SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["ggConnectionString"].ToString());
        String strSql = "";
        SqlCommand comando;
        SqlDataAdapter adapter;
    } catch (Exception ex)
    {
        MessageBox.Show(Form.ActiveForm, "Error: " + ex.ToString());
    }
}
