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
    
                    cn.Open(); // have to explicitly open connection (fetches from pool)
    
                    MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader rdr = cmd.ExecuteReader();
    
                    while (rdr.Read()){
                        Console.WriteLine(string.Format("user_id = {0}", rdr["user_id"].ToString()));   
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{oops - {0}", ex.Message);
                }
                finally
                {
                    cn.Dispose(); // return connection to the pool
                }
                Console.WriteLine("press any key...");
                Console.ReadKey();
            }
        }
    }
