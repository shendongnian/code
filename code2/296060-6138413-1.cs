    public void UpdateMedicineRecordQuantity(string tableName, string attributeName, string productId, string attributeValue)
    {
        using (var conn = new SqlConnection("YOUR ConnectionString HERE"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "UPDATE " + tableName + "SET " + attributeName+ " = @attributeValue where productid = @productid";
            cmd.Parameters.AddWithValue("@attributeValue", attributeValue);
            cmd.Parameters.AddWithValue("@productid", productId);
            cmd.ExecuteNonQuery();
        }
    }
