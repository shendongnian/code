    if (oConnection.State != ConnectionState.Closed)
    {
         oConnection.Close();
         oConnection.Dispose();
    }
