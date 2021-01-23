    private void Commit(ComplexDataSet[] data)
    {
        using (var connection = new SqlConnection("connection string..."))
        {
            connection.Open();
            // insert your data here...
        }
    }
