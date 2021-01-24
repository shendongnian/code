    public DL
    {
        private static string connectionString = "...";
        public static IEnumerable<T> GetAll<T>() 
        {
             using (var cn = new SqlConnection(connectionString))
             {
                 cn.Open():
                 //...
             }
        }
    }
