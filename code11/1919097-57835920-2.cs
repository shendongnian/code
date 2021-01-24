    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("SELECT MAX(OilId) FROM Oiltbl", conn)) {
        conn.Open();
        object result = command.ExecuteScalar();
        if (result == null) {
            txtoid.Text = "O001";
        } else {
            int UserId = (int)result; // Assuming that OilId is an int column.
            int ProductIdInt = UserId + 1;
            txtoid.Text = $"O{ProductIdInt:d3}";
        }
    }
