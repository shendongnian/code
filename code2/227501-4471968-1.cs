    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    // addded these
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using System.Data;
    
    namespace mysql
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string DB_CONN_STR = "Server=127.0.0.1;Uid=foo_dbo;Pwd=pass;Database=foo_db;";
    
                MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
                
                try {
    
                    string sqlCmd = "select * from users order by user_id";
                    
                    MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
                    adr.SelectCommand.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)
    
                    foreach (DataRow dr in dt.Rows){
                        Console.WriteLine(string.Format("user_id = {0}", dr["user_id"].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{oops - {0}", ex.Message);
                }
                finally
                {
                    cn.Dispose(); // return connection to pool
                }
                Console.WriteLine("press any key...");
                Console.ReadKey();
            }
        }
    }
