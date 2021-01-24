    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (left_txtbox == true) Check(); // if txtbox has been left, do the check
            textBox_fn.Text = string.Empty;
            textBox_ln.Text = string.Empty;
            if (conn.State != ConnectionState.Open) { conn.Close(); conn.Open(); }
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [table1] WHERE firstn='" + listBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox_fn.Text = dr["firstn"].ToString();
                textBox_ln.Text = dr["lastn"].ToString();
            }
            conn.Close();
        }
