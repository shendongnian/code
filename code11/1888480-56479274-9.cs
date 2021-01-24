      int status = IsUserLogged(txtboxUsername.Text, txtboxPassword.Text);
      if (status == 0) {
        MessageBox.Show("Either username or password is incorrect.", 
                        "THD FAM", 
                         MessageBoxButtons.OK, 
                         MessageBoxIcon.Error);
        return;
      } 
      else if (status == 1) {
        MessageBox.Show("This account is currently online, you forgot to logout. Please approach administrator for help. Thank you", 
                        "THD FAM", 
                         MessageBoxButtons.OK, 
                         MessageBoxIcon.Error);
        return;
      }
