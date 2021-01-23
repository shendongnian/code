    class SqlHelper
    {
        public static SqlConnection GetConn()
        {
            SqlConnection returnValue = new SqlConnection("MyConnectionString");
            returnValue.Open();
            return returnValue;
        }
    }
