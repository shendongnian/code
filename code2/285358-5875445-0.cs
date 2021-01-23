    string updateQuery = "Update ..... Where ...."; //do your magic here
    OldDbcommand command = new OleDbCommand(updateQuery);
    command.Connection = conn;
    conn.Open();
    con.ExecuteNonQuery();
    conn.Close();
