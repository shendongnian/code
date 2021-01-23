    object ret;
    ADODB.Recordset rs = null;
    Connect();
    try
    {
        // Why the lock? Is your code sharing the same connection across threads?
        lock (_conn) 
            rs = _conn.Execute(query, out ret, -1);
        rs.Close();
    }
    finally
    {
        if (rs != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject( rs );
    }
    return (int)ret;
