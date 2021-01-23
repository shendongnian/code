    // Get the new password
    string password = "New Password";
    // Set the appropriate property
    if (certain condition)
    {
       Properties.Settings.Default.Password1 = password;
    }
    else
    {
       Properties.Settings.Default.Password2 = password;
    }
    // Save the new password
    Properties.Settings.Default.Save();
