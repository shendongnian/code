    public class DataClass {
            private IDbConnection cn;
            
            public DataClass() 
               : this(new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseName"].ToString()) {}
            
            public DataClass(IDbConnection conn) {
               cn = conn;
            }
            public DataSet ds(SqlCommand cmd)
            {
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            }
         }
