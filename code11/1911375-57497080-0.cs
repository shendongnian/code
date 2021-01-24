    using (connection = new SqlConnection(connectionString))
    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Davaoci", connection))
    {
        DaDavaoci.SelectCommand = SlctDavaoci;
        DaDavaoci.Fill(ds, "TblDavaoci");
    }
