    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data.MySqlClient;
     
    namespace ConsoleApplication3
    {
        class Program
        {
            public static string db = &quot;server=localhost;database=dsc;uid=root;password=&quot;;
            static void Main(string[] args)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(db);
                    con.Open(); // connection must be openned for command
                    MySqlCommand cmd = new MySqlCommand(&quot;Select * FROM `tablename`&quot;, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(&quot;id&quot;) + &quot;: &quot; + reader.GetString(&quot;name&quot;) + &quot; - &quot; + reader.GetString(&quot;hs&quot;));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(&quot;Error: &quot;+ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
