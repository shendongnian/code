    using MySql.Data.Types;
    using MySql.Data.MySqlClient;    
    
    private void Function()
        {
                        //Set up connection, SqlHost/etc are classwide and declared elsewhere:
                        MySql connection = new MySqlConnection("SERVER=" + SqlHost + ";DATABASE=" + DatabaseName + ";UID=" + user + ";PASSWORD=" + password + ";pooling=false");
        
                        //Setup query:
                        MySqlCommand command = connection.CreateCommand();
                        MySqlDataReader Reader;    
                        command.CommandText = "your query here";
        
                        //Connect to relation system and execute query:
                        connection.Open();
                        Reader = command.ExecuteReader();
                        while(Reader.Read())
                        {
                            MessageBox.Show("here's a row from the query response: " + Reader[0].ToString());
                        }
        
                        //Clean up:
                        connection.Close();
                        Reader.Close();
        }
