    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;
    
    namespace SQLServerChecker
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Use a dictionary to associate a friendly name with each connection string.
                IDictionary<string, string> connectionStrings = new Dictionary<string, string>();
    
                connectionStrings.Add("Test1", "connectionString1");
                connectionStrings.Add("Test2", "connectionString1");
    
                foreach (string databaseName in connectionStrings.Keys)
                {
                    try
                    {
                        string connectionString = connectionStrings[databaseName];
    
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            Console.WriteLine("Connected to {0}", databaseName);
                        }
                    }
                    catch
                    {
                        // Handle the connection failure.
                        Console.WriteLine("FAILED to connect to {0}", databaseName);
                    }
                }
    
                // Wait for a keypress to stop the console closing.
                Console.WriteLine("Press any key to finish.");
                Console.ReadKey();
            }
        }
    }
