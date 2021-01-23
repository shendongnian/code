    using(SqlConnection connection = new SqlConnection("myConnectionString"))
    {
        using(SqlCommand command = new SqlCommand("dbo.SomeProc"))
        {
            // Execute the command, when the code leaves the using block, each is disposed
        }
    }
