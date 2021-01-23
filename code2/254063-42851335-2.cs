    using System.Data;
    using System.Data.Odbc;
    using System.Data.SqlClient;  //using this you can replace instead odbc to sql
        
    // Example SqlCommand, SqlDataAdapter
    class DataBaseConnection
    {
        private OdbcConnection conn1 = new OdbcConnection(@"FILEDSN=C:/OTPub/Ot.dsn;" + "Uid=sa;" + "Pwd=otdata@123;"); //"DSN=Ot_DataODBC;" + "Uid=sa;" +  "Pwd=otdata@123;"
              
        //insert,update,delete
        public int SetData(string query)
        {
            try
            {
                conn1.Open();
                OdbcCommand command = new OdbcCommand(query, conn1);
                int rs = command.ExecuteNonQuery();
                conn1.Close();
                return rs;
            }
            catch (Exception ex)
            {
                conn1.Close();
                throw ex;
            }
        }
        //select
        public System.Data.DataTable GetData(string sql)
        {
            try
            {
                conn1.Open();
                OdbcDataAdapter adpt = new OdbcDataAdapter(sql, conn1);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                conn1.Close();
                return dt;
               
            }
            catch (Exception ex)
            {
                conn1.Close();
                throw ex;
            }
        }
    
    }
