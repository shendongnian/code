    private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data  Source=C:\\Documents and Settings\\mayur patil\\My Documents\\Dairy_db\\tblCompany.mdb";
            string sql = "DELETE FROM tblCompany WHERE (CoCode = 1)";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
    
        }
