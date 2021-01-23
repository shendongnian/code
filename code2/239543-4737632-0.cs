    OleDbDataReader getMe = cmd.ExecuteReader();
    int index = getMe.GetOrdinal("column_name");
    while (getme.Read())
    {
        MessageBox.Show(getMe.GetString(index));
    }
    
