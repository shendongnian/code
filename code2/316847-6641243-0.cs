     public void Home_Load(...params...)
     { 
        Login log = new Login();
          if(log.ShowDialog() == DialogResult.Ok)
             {
                // enable the menu here
             }
           else 
            {
              // let the menu disabled or exit the application here
            }
     }
