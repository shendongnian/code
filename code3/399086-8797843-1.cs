    public class BAL
    { 
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbCustConn"].ToString();
        private static string cmdStr = "Select * from MainDB";
        public static DataTable Load() // what is this for? (loads all the records from the database)
        {
            using (var adp = new SqlDataAdapter(cmdStr, connStr))
            {
                var ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
