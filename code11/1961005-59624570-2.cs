    string emailAddress = txtEmail.Text;
    string password = txtpwd.Text;
    bool rememberMe = chkRememberMe.Checked;
    var hashedPassword = Security.GetHash(password);
    
    User u = db.Users.SingleOrDefault(
    			x => x.EmailAddress == emailAddress &&
    			x.Hash == hashedPassword 
    			);
