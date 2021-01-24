    private bool IsRegistrationDataValid() {
      if (string.IsNullOrWhiteSpace(txtFname.Text)) {
          if (txtFname.CanFocus) 
            txtFname.Focus();
          MessageBox("Please, fill in first name."); 
          return false;
      }
      //TODO: Add more cases here
      return true; 
    }
