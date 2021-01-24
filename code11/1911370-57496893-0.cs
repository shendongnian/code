    private void PopuniDgDavaoci()
    {
        using (connection = new SqlConnection(connectionString))
        {
             connection.Open(); //<< open the sql connection
             using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Davaoci", connection))
                {
                    DaDavaoci.SelectCommand = SlctDavaoci;
                    DaDavaoci.Fill(ds, "TblDavaoci");
                }
        }
    }
