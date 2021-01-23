    using (SqlDataReader Ddldr = DlistCmd.ExecuteReader())
    {
        while (Ddldr.Read())
        {
            switch (Ddldr.GetInt32(0))
            {
                ... your cases here
                default:
                    break;
            }
        }
    }
