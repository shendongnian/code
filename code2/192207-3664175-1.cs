    public bool AuthenticateUser(string username, string password)
    {
        // I don't validate password here (see TODO below)
        var user = db.User.FirstOrDefault(u => u.UserName == username && u.Status);
    
        if(user != null)
        {
            var rehash = Hashing.Hash(password, user.PasswordSalt); // PasswordSalt is a byte array
            if(rehash.SequenceEqual(user.Password))
            {
                return true;
            }
            else
            {
                Logger.LogUnsuccessfulAuthentication(user);
                // TODO: Increase user-login failure count and system-wide failure count
            }
        }
    
        return false;
    }
