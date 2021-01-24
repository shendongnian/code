    public class MyDatabase
    {
        private DbConnection _myConnection;
        public MyDatabase(DbConnection connection)
        {
            _myConnection = connection;
        }
        public void RunMethod()
        {
            try
            {
                // Do your stuff here
            }
            catch (Exception ex)
            {
                // Log execption details 
            }
        }
    }
    public class Context
    {
        public void Run()
        {
            using(SqlConnection sqlConnection = new SqlConnection())
            {
                 sqlConnection.ConnectionString = "...";
                 sqlConnection.Open();
                 MyDatabase db = new MyDatabase(sqlConnection);
                 db.RunMethod();
                 db.RunMethod();
            }
        }
    }
