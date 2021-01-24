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
It would also be beneficial to remove the Try Catch once you have this code fully operational - or at least only catch external errors thrown from the SqlAdapter
