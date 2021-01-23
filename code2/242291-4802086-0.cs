    public void delete_click()
    {
        using(SqlConnection _con = new SqlConnection(-your-connection-string-here-))
        using(SqlCommand _cmdDelete = new SqlCommand(_con, "dbo.proc_delete"))
        {
            _cmdDelete.CommandType = CommandType.StoredProcedure;
            // add parameter
            _cmdDelete.Parameters.Add("@PrimaryKey", SqlDbType.Int);
            _cmdDelete.Parameters["@PrimaryKey"].Value = (your key value here);
            // open connection, execute command, close connection
            _con.Open();
            _cmdDelete.ExecuteNonQuery();
            _con.Close();
        }
    }
