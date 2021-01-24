    private void btnRegister_Click(object sender, EventArgs e) {
      if (!IsRegistrationDataValid())
        return;
      else if (TryRegister()) {
        MessageBox.Show("Successfully registered.");
        Hide();
        login.Show(); 
      }
      else {
        MessageBox.Show($"Sorry, \"{txtFname.Text}\" has been taken. Put another one.");
    
        txtFname.Clear();
    
        // Let's be nice and put keyboard focus on the textbox we ask to change
        if (txtFname.CanFocus) 
          txtFname.Focus();
      } 
    }
