    using System.Data.SqlClient;
    using System.Data;
    
    public class DBAccess{
        private string strCon = "Data Source=YourServer;Initial Catalog=YourDBName;etc";
        public string GetResult(){
        
            string strQuery = "Exec YourProcedure Param1";
            SqlCommand cmdSql = new SqlCommand(strQuery);
            SqlConnection conSql = new SqlConnection(strCon);
            conSql.Open();
            cmdSql.Connection=conSql;
            SqlDataReader dreSql = cmdSql.ExecuteReader();
            dreSql.Read();
            // here I'm trying to read the item of the row on the column named Result
            return dreSql["Result"].ToString();
    
        }
    }
