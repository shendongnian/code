     private void loggedIn(object o)
     {
         if(InvokeRequired)
             Invoke(new Action<object>(loggedIn), o);         
         else
         {
            Console.WriteLine("Logged in and Active.");
            lblStatus.Text = "Online";          
         }
     }
