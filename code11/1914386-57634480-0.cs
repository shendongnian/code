    public static int TransitTime(string postcode, ApiDbContext con)
    {
        var query = "SELECT top 1 Mins from Transit where postcode = @Postcode order by mins desc;";
        var p1 = new SqlParameter("@Postcode", postcode);
        var result = 0;
        using (var command = con.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = query;
            command.Parameters.Add(p1);
            con.Database.OpenConnection();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) result = (int)reader[0];
            }
        }
        return Convert.ToInt32(result);
    }
