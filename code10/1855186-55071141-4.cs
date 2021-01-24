    using (var conn = new SqlConnection("Data Source=DESKTOP...;Integrated Security=True")) {
        try
        {
            conn.Open();
            ...
        }
        catch (Exception ex)
        {
            ...
        }        
    }
