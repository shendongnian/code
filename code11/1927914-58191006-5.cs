    var result = elite.Users.Where(user => user.UserName == txtuser.Text 
                                        && user.UserPWD == txtpass.Text).FirstOrDefault();
    if ( result != null )
    {
      MainForm mainForm = new MainForm();
      mainForm.ShowDialog();
      Hide();
      Close();
    }
