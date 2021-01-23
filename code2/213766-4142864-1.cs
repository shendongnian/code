    bool xValValid = Int32.TryParse(txtXPos.Text, out val1);
    if(!xValValid){
      txtXPos.Text = "";
      validated = false;
      MessageBox.Show("You have an invalid value entered. Please check your entry.", "Invalid Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
    }
