    public class Authorize
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class Add
    {
        public void Login()
        {
            Authorize authorize = new Authorize();
            authorize.Username = usernameTextBox.Text;
            authorize.Password = passwordTextBox.Text;
            // Todo: Rest of login logic here
        }
        // Todo: Other code here...
    }
    public class Display
    {
        public void Show()
        {
            Authorize authorize = new Authorize();
            // uh oh, Username and Password are null!
        }
        // Todo: Other code here...
    }
