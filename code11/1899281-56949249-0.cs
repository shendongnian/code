    private void Button3_Click(object sender, EventArgs e)
    {
        var selectedRows = dataGridView1.SelectedRows.Cast<DataGridViewRow>().ToArray();
        for (int i = 0; i < selectedRows.Length; i++)
        {
            if(selectedRows[i].Cells[idColumn.Index].Value is int id)
            {
                string deleteQuery = $"DELETE FROM {comboBox1.SelectedItem} WHERE id= " + id;
                form1.conn = new SqlConnection($"Server = {form1.ServerBox.Text }; Database = { form1.DBBox.Text}; Trusted_Connection = True");
                form1.cmd = new SqlCommand(deleteQuery, form1.conn);
                form1.conn.Open();
                form1.cmd.ExecuteNonQuery();
                form1.conn.Close();
                dataGridView1.Rows.Remove(selectedRows[i]);
            }
        }
    }
