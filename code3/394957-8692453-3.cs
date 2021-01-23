    public static int CountCars()
    {
        using(SqlConnection conn = new SqlConnection(connectionString))
        using(SqlCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT COUNT(1) FROM Carsd";
     
            return (int)cmd.ExecuteScalar();
        }
     
    }
