    private void EndConnection(object sender, EventArgs e)
    {
        if (_conn == null)
        {
           return;
        }
        if (_conn.Connection.State == ConnectionState.Open)
        {
             _conn.Close();
        }
        _conn.Dispose(); // always dispose even if never opened.
    }
