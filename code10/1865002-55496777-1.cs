    using System;
    using System.Data.SqlClient;
    
    class Program
    {
        static void Main(string[] args)
        {
            //string conStr = "Data Source=10.21.168.30,1433;Initial Catalog=СС_Vesy_1_19_03_12_14_22_18R;Persist Security Info=True;User ID=mic;Password=mic";
            string conStr = "Data Source=127.0.0.1,1433;Initial Catalog=Test;Persist Security Info=True;User ID=mac;Password=mac";
    
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SELECT @@VERSION", con);
    
            con.Open();
            string version = (string)cmd.ExecuteScalar();
    
            Console.WriteLine(version);
            Console.ReadKey();
        }
    }
