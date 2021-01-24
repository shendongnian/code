    if ( elite.Users.Any(user => user.UserName == txtuser.Text 
                              && user.UserPWD == txtpass.Text) )
    {
      MainForm mainForm = new MainForm();
      mainForm.ShowDialog();
      Hide();
      Close();
    }
