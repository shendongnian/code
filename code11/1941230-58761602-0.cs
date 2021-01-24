    // Represents data which can be different for different drinks
    public class DrinkSelection
    {
        public string Name { get; set; }
        public int Qty { get; set; }
    }
    public class DrinkPurchase
    {
        private readonly string _userName;
        private readonly string _userCompany;
        public DrinkPurchase(string userName, string userCompany)
        {
            _userName = userName;
            _userCompany = userCompany;
        }
        public void Save(DrinkSelection drink)
        {
            var insert = @"
                INSERT INTO tbDrinks (DrinkName, DateOfOrder, Qty, UserName, UserCompany)
                VALUES (@DrinkName, @DateOfOrder, @Qty, @UserName, @UserCompany)
            ";
            var parameters = new[]
            {
              new SqlParameter("@DrinkName", SqlDbType.Varchar) { Value = drink.Name },
              new SqlParameter("@DateOfOrder", SqlDbType.DateTime) { Value = DateTime.Today },
              new SqlParameter("@Qty", SqlDbType.Varchar) { Value = drink.Qty },
              new SqlParameter("@UserName", SqlDbType.Varchar) { Value = _userName },
              new SqlParameter("@UserCompany", SqlDbType.Varchar) { Value = _userCompany }
            };
            using (var connection = new SqlConnection(connectionString)) 
            using (var command = connection.CreateCommand())
            {
                command.CommandText = insert;
                command.Parameters.AddRange(parameters);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
