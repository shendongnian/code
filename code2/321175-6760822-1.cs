    using (SqlCeConnection conn = new SqlCeConnection("Data Source = Database1.sdf"))
    using (SqlCeCommand comm = new SqlCeCommand("DELETE FROM table1 WHERE slno = 2", conn))
    {
        conn.Open();
        comm.CommandType = CommandType.Text;
        comm.ExecuteNonQuery();
    }
