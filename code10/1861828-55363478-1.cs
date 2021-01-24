    public class LoginHandler
    {
        public static void UserAuth(string input_username, string input_password)
        {
            DatabaseHandler dataBase = new DatabaseHandler();
            User result = dataBase.MySqlGetUserByName(input_username);
            if(result == null)
            {
                // Send your message using a static method in the user class
                // User.SendMessage("User with username {input_username} not found!");
            }
            else
            {
                // User ok. return it? or do something with its data?
            }
        }
    }
