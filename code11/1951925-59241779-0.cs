    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataTable dt = new DataTable();
        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        int eventID = int.Parse(row.Cells[0].Value.ToString());
        using (SqlConnection conn = new SqlConnection(@"connection string"))
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Brand Where EventID=" + eventID.ToString(), conn);
            DataSet Ds = new DataSet();
            sda.Fill(Ds, "T1");
            dataGridView2.DataSource = Ds.Tables["T1"];
        }
    }
