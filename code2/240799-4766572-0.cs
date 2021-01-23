    private void btnLogin_Click(object sender, EventArgs e)
    {
          btnLogin.Enabled = false; 
    
          // initially btnLogin has a DialogResult property set to None
          Authenticate();
          // better place call to Authenticate in try catch blocks
          // to prevent btnLogin in a disabled state forever if Authenticate fails with
          // an exception ...
          // also if an exception occurs show that in a message box
                
          btnLogin.Enabled = true;
    }
