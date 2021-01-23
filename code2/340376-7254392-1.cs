    using (SqlConnection con = new SqlConnection("..."))
    {
        using (SqlCommand Command = new SqlCommand(SQL, con))
        {
            Command.Parameters.Add("@EventName", EventName);
        }
    }
    {
        con.Open();
        ...
    }
