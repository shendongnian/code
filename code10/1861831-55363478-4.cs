    public class DatabaseHandler
    {
        public User MySqlGetUserByName(string input_username)
        {
            User result = null;
            try
            {
                string query = "SELECT * FROM users WHERE username = @input";
                using(MySqlConnection cnn = new MySqlConnection(......))
                using(MySqlCommand command = new MySqlCommand(query, cnn))
                {
                    cnn.Open();
                    command.Parameters.AddWithValue("@input", input_username);
                    using(MySqlDataReader dataReader = command.ExecuteReader())
                    {
                       if (dataReader.Read())
                       {
                           result = new User();
                           result.ID = Convert.ToInt32(dataReader[0]);
                           ..... and so on with the other user properties ....
                       }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // Return the user to the caller. If we have not found the user we return null
            return result;
        }
    }
