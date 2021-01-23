    public class DbConnectionHelper {
       public DataSet DBConnection(string TableName, SqlParameter[] p, string Query, CommandType cmdText) {
        string connString = @ "your connection string here";
        //Object Declaration
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        try {
         //Get Connection string and Make Connection
         con.ConnectionString = connString; //Get the Connection String
         if (con.State == ConnectionState.Closed) {
          con.Open(); //Connection Open
         }
         if (cmdText == CommandType.StoredProcedure) //Type : Stored Procedure
         {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = Query;
          if (p.Length > 0) // If Any parameter is there means, we need to add.
          {
           for (int i = 0; i < p.Length; i++) {
            cmd.Parameters.Add(p[i]);
           }
          }
         }
         if (cmdText == CommandType.Text) // Type : Text
         {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = Query;
         }
         if (cmdText == CommandType.TableDirect) //Type: Table Direct
         {
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = Query;
         }
         cmd.Connection = con; //Get Connection in Command
         sda.SelectCommand = cmd; // Select Command From Command to SqlDataAdaptor
         sda.Fill(ds, TableName); // Execute Query and Get Result into DataSet
         con.Close(); //Connection Close
        } catch (Exception ex) {
    
         throw ex; //Here you need to handle Exception
        }
        return ds;
       }
      }
