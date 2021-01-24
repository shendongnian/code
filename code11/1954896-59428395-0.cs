using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
namespace DBconnector
{
    class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            Console.WriteLine("Initializing Connection...");
            server = "192.168.0.60";
            database = "devDB";
            uid = "user";
            password = "password";
            string connectionString;
            connectionString = "SERVER="+server+";" + "UID="+uid+";" + "DATABASE="+database+";" + "PASSWORD="+password+";";
            connection = new MySqlConnection(connectionString);
        }
         
        /* Sample select statement from a table in the DB */
        public List<string> SelectFBOEntries(String statement)
        {
            string query = statement;
            List<string> response = new List<string>();
            if (this.OpenConnection())
            { 
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    response.Add(dataReader["ID"] + "");
                    response.Add(dataReader["Name"] + "");
                    response.Add(dataReader["Age"] + "");
                    response.Add(dataReader["DOB"] + "");
                    response.Add(dataReader["ZIP"] + "");
                }
                dataReader.Close();
                this.CloseConnection();
                return response;
            }
            else
            {
                return response;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Closing Connection");
                return false;
            }
        }
