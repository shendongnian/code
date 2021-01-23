     private void loggedIn(object o)
     {
         Console.WriteLine("Logged in and Active.");
         Action act = () => lblStatus.Text = "Online";
         Invoke(act);   
     }
