    using System.Data.SqlClient;
    class MyDataBase
    {
        public SqlConnection MyConnection = new SqlConnection(ADD CONNECTION STRING HERE);
        public SqlCommand MyCommand = MyConnection.CreateCommand();
    }
