    try
    {
        using (SqlConnection connection = new SqlConnection("Your connection string here"))
        {
            using (SqlCommand command = new SqlCommand("your sql here", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                }
            }
        }
    }
    catch (Exception exception)
    {
        System.Diagnostics.Debug.WriteLine(exception);
    }
