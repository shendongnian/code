    private void button1_Click(object sender, EventArgs e)
    {
        string ConnString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ts\Documents\testDB.accdb");
        using (OleDbConnection conn = new OleDbConnection(ConnString))
        {
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE [Table4] SET [EmpName] = ?, [Age] = ?, [Mobile] = ?  WHERE [ID] = ?";
    
                cmd.Parameters.AddWithValue("@EmpName", OleDbType.VarChar).Value = nametextBox2.Text;
                cmd.Parameters.AddWithValue("@Age", OleDbType.VarChar).Value = agetextBox3.Text;
                cmd.Parameters.AddWithValue("@Mobile", OleDbType.VarChar).Value = mobiletextBox4.Text;
                cmd.Parameters.AddWithValue("@ID", OleDbType.VarChar).Value = idtextBox1.Text;
                cmd.Connection = conn;
                conn.Open();
    
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }
        Form1_Load(sender, e);
        MessageBox.Show("record updated ");
    }
