    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace ConsoleApp21
    {
        class Program
        {
            static void Main()
            {
                // these are read from the command line as the plain text
                const string userLogin = "darko";
                const string passwordLogin = "MyTestPas";
    
                // Change to match your connection string
                var sqlcon = new SqlConnection("Integrated Security = true; Initial Catalog = your database; Server = your server");
                sqlcon.Open();
                var cmdLogin = new SqlCommand
                {
                    Connection = sqlcon, CommandType = CommandType.StoredProcedure, CommandText = "spLogin"
                };
                cmdLogin.Parameters.Add(new SqlParameter("@uname", SqlDbType.NVarChar)).Value = userLogin;
                cmdLogin.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar)).Value = passwordLogin;
                
    
                var loginReader = cmdLogin.ExecuteReader();
                while (loginReader.Read())
                {
                    var user = new User
                    {
                        Id = loginReader.GetInt32(0),
                        LoginName = loginReader.GetString(1),
                     
                        UserRole = loginReader.GetString(3)
                    };
                    Console.Write(user.LoginName );
                    
                }
                loginReader.Close();
                Console.ReadLine();
            }
        }
    
        public class User
        {
            public string UserRole { get; set; }
            public string LoginName { get; set; }
            public Byte PasswordHash { get; set; }
    
      
            public int Id { get; internal set; }
    
          
        }
    }
