    public class Display
    {
        public void Show(Authorize authorize)
        {
            // Now we have the values that the Login method created...
        }
        // ...
    }
    public class Add
    {
        public void Login()
        {
            Authorize authorize = new Authorize();
            authorize.Username = usernameTextBox.Text;
            authorize.Password = passwordTextBox.Text;
            display.Show(authorize);
        }
        // ...
    }
