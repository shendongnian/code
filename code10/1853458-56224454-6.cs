    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.IO;
    using System.Net;
    
    namespace GetIPVersionSQLSRV
    {
        class Program
        {
            private static String config = ConfigurationManager.AppSettings["texto"];
            private static String cadena = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World! " + config);
                using(SqlConnection conn = new SqlConnection(cadena))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("SELECT @@VERSION;", conn))
                        Console.WriteLine(comm.ExecuteScalar());
                }
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://api.ipify.org?format=json");
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                using (Stream strm = res.GetResponseStream())
                using (StreamReader read = new StreamReader(strm))
                    Console.WriteLine(read.ReadToEnd());
                req = null;
    
                Console.ReadKey(false);
            }
        }
    }
    
