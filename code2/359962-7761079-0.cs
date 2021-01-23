    public class MyModel
    {
        public int ModelId { get; set; }
        public string FirstName { get; set; }
    }
     
    public class SqlMyModelRespoitory : IMyModelRepository // optional for DI/IoC, assume interface with GetSingleModel method
    {
        public MyModel GetSingleModel()
        {
            MyModel model;
            string connString = "server=10.1.1.1;database=MyDb;uid=me;pwd=hidden";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "p_GetMyModelFromDb";
     
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new MyModel 
                            {
                               ModelId = Convert.ToInt32(reader[0]),
                               FirstName = reader[1].ToString()
                            };
                        }
                    }
                }
            }
            return model;
        }
    }
