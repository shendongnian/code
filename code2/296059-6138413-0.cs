    public void UpdateMedicineRecordQuantity(int productId, int quantity)
    {
        using (var conn = new SqlConnection("YOUR ConnectionString HERE"))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "UPDATE medicinerecord SET quantity = @quantity where productid = @productid";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@productid", productId);
            cmd.ExecuteNonQuery();
        }
    }
