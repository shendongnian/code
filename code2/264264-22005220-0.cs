       public bool VailidateEntriesForAccount()
        {
           if (!(txtMailId.Text.Trim() == string.Empty))
            {
                if (!IsEmail(txtMailId.Text))
                {
                    Logger.Debug("Entered invalid Email ID's");
                    MessageBox.Show("Please enter valid Email Id's" );
                    txtMailId.Focus();
                    return false;
                }
            }
         }
       private bool IsEmail(string strEmail)
        {
            Regex validateEmail = new Regex("^[\\W]*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z] {2,4}[\\W]*,{1}[\\W]*)*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z]{2,4})[\\W]*$");
            return validateEmail.IsMatch(strEmail);
        }
