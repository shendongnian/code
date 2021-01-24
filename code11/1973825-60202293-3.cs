    private bool TryRegister() {
      if (!IsRegistrationDataValid()) 
        return false;
      System_Functions register = new System_Functions();
    
      return (register.Register_Receptionist(txtFname.Text, 
                                             txtMname.Text, 
                                             txtLname.Text, 
                                             txtPassword.Text, 
                                             txtPasswordVerify.Text));
    }
