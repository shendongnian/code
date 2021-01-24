c#
public event EventHandler<string> PasswordInput;
// the function you are going to call when you want to raise the event
private void NotifyPasswordInput(string password)
{
    PasswordInput?.Invoke(this, password);
}
// button click event handler
private void OnButtonClick(object sender, RoutedEventArgs e)
{
    // get the password from the TextBox
    string password = myTextBox.Text;
    // raise the event
    NotifyPasswordInput(passowrd);
}
**Page**
c#
...
Password_Prompt PassWindow = new Password_Prompt();
// add this part to subscribe to the event
PassWindow.PasswordInput += OnPasswordInput;
PassWindow.Show();
...
// and the method to handle the event
private void OnPasswordInput(object sender, string password)
{
    // use the password from here
}
