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
