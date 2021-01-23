    using (var connection = new OleDbConnection("your connection string"))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "select FoodName, Price from tablename where FoodID = @FoodID";
        command.Parameters.AddWithValue("FoodID", int.Parse(txtId.Text));
        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            txtName.Text = reader["FoodName"].ToString();
            txtPrice.Text = reader["Price"].ToString();
        }
    }
