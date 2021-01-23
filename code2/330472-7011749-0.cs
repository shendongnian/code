    public static bool checkConnection()
    {
        SqlConnection conn = new SqlConnection("mydatasource");
        try
        {
             conn.Open();
             return true;
        }
        catch (Exception ex) { return false; }
    }
