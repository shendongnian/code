    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand("update BlockReport set Supplier = @SupplierEntry where Job# = @JobNumberEntry", connection);
        command.Parameters.AddWithValue("@JobNumberEntry", JobNumberEntry.Text);
        command.Parameters.AddWithValue("@SupplierEntry", SupplierEntry.Text);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
