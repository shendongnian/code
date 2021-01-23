    public class WorkWithDataBase
    {
        private void SomeMethod()
        {
            using(SqlConnection sqlConn = new SqlConnection("connectionString"))
            {
                //rest of the code
                sqlConn.Open(); //if needed)
                //and no need to close the connection, becuase "using" will take care of that!
            }
        }
    }
