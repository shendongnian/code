    string username = string.Empty;
    string password = string.Empty;
    using (LoginForm form = new LoginForm ())
     {
         DialogResult result = form.ShowDialog();
         if (result == DialogResult.Ok)
         {
             username = form.Username;
             password = form.Password;
         }
     }
