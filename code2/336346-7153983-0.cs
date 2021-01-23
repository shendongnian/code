    using System;
    using System.Data;
    using System.Data.SqlClient;
    class Program
    {
        static void Main(string[] args)
        {
            string sqlConnectString = "Data Source=(local);Integrated security=SSPI;Initial Catalog=MyDatabase;";
            string sqlDelete = "DELETE FROM MyTable WHERE Id = 2";
            SqlConnection connection = new SqlConnection(sqlConnectString);
            SqlCommand command = new SqlCommand(sqlDelete, connection);
            connection.Open( );
            int rowsAffected = command.ExecuteNonQuery( );
            Console.WriteLine("{0} row(s) affected.", rowsAffected);
            Console.WriteLine("Record with Id = 2 deleted.");
            connection.Close( );
        }
    }
