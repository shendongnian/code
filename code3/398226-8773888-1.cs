    if(Properties.Settings.Default.FirstRun == true)
    { lblGreetings.Text = "Welcome New User";
      //Change the value since the program has run once now
      Properties.Settings.Default.FirstRun = false;
      Properties.Settings.Default.Save(); }
    else
    { lblGreetings.Text = "Welcome Back User"; }
