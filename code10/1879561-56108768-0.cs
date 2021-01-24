    User user = null;
    string line;
    while ((line = read.ReadLine()) != null)
    {
       if (line.Contains(user) && line.Contains(password))
       {
          login.Show();
          user = new User() { Username = user, Password = password };
          break;
       }
    }
    if (user == null) MessageBox.Show("The username or Password is Incorrect"); 
