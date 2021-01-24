    using System;
    using System.Data.SqlClient;
    
    namespace ConsoleApp13
    {
        class Program
        {
            static void Main(string[] args)
            {
                //define the connection string of azure database.
                var cnString = "Server=tcp:xxx.database.windows.net,1433;Initial Catalog=xxx;Persist Security Info=False;User ID=xxx;Password=xxx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //define the insert sql command, here I insert data into the student table in azure db.
                string cmdText = @"insert into student
                       (name,age)
                       values(@name, @age)";
                using (SqlConnection con = new SqlConnection(cnString))
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", "yang1");
                    cmd.Parameters.AddWithValue("@age", 20);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
    
                Console.WriteLine("completed***");
                Console.ReadLine();
            }
        }
    }
