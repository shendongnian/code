    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    
    public class PullDataTest
    {
        // your data table
        private DataTable dataTable;
    
        public PullDataTest()
        {
        }
    
        // your method to pull data from database to datatable   
        public void PullData()
        {
            string connString = @"your connection string here";
            string query = "select * from table";
    
            SqlConnection conn = new SqlConnection(connString);        
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
    
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
        }
    }
