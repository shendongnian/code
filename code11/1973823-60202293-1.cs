    private void btnRegister_Click(object sender, EventArgs e)
    {
        //TODO: you may want to add validation here, e.g.:
        if (string.IsNullOrWhiteSpace(txtFname.Text)) {
          if (txtFname.CanFocus) 
            txtFname.Focus();
          MessageBox("Please, fill in first name."); 
          return;
        }
        System_Functions register = new System_Functions();
    
        if (register.Register_Receptionist(txtFname.Text, 
                                           txtMname.Text, 
                                           txtLname.Text, 
                                           txtPassword.Text, 
                                           txtPasswordVerify.Text))
        {
            // The name is valid and has been registered successfully
            MessageBox.Show("Successfully registered.");
            Hide();
            login.Show();
        } 
        else 
        {
            // The name has been taken
            MessageBox.Show($"Sorry, \"{txtFname.Text}\" has been taken. Put another one.");
    
            txtFname.Clear();
    
            // Let's be nice and put keyboard focus on the textbox we ask to change
            if (txtFname.CanFocus) 
              txtFname.Focus();
        }
    }
