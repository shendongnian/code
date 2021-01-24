    eg
    
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp24
    {
        static class DbConnectionExtensions
        {
            public static int ExecuteNonQuery(this SqlConnection conn, String sqlQuery)
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery; // this is the statement above which is 
                                            //passed in
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
    
                return cmd.ExecuteNonQuery();
       
            }
    
            public static DataSet ExecuteQuery(this SqlConnection conn, String sqlQuery)
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = null;
                SqlDataAdapter adapter = null;
               
                cmd = new SqlCommand();
                cmd.CommandText = sqlQuery; // this is the statement above which is 
                                            //passed in
                cmd.CommandTimeout = 0;
                cmd.Connection = conn;
    
                adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
    
                return ds;
               
            }
    
        }
        class Program
        {
    
    
    
            static void Main(string[] args)
            {
                using (var conn = new SqlConnection("Server=localhost;integrated security=true;database=tempdb"))
                {
                    conn.Open();
    
                    conn.ExecuteNonQuery("create table tLocation_102(id int)");
    
                    var ds = conn.ExecuteQuery("SELECT 'DROP TABLE  ' + NAME FROM sys.tables WHERE NAME LIKE 'tLocation[_]%'  ");
    
                    var dt = ds.Tables[0];
                    Console.WriteLine(dt.Rows.Count);
    
                }
    
                
    
                Console.ReadKey();
            }
        }
    }
