    using System.Data;
    if (conn.State == ConnectionState.Open)
    {
        return true;
    }
    else 
    {
        return false;
    } 
