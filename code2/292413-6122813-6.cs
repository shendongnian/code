    public int ExecuteNonQuery()
    {
        try
        {
            // m_command holds the inner, true, SqlCommand object.
            return m_command.ExecuteNonQuery();
        }
        catch
        {
            LogCommand();
            throw; // pass exception on!
        }
    }
