    using MySql.Data.MySqlClient;
    using System;
    namespace SQLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello world"); //for testing
                string server = "remotemysql.com";
                string database = "Score";
                string uid = "xxxx";
                string password = "xxxx";
                string connectionString;
                connectionString = "SERVER=" + server + "; PORT = 3306 ;" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PWD=" + password + ";";
                MySqlConnection mycon = new MySqlConnection(connectionString);
                mycon.Open(); //error
                Console.WriteLine("Connection Open  !");
                mycon.Close();
            }
        }
    }
