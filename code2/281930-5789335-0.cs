    if(status.HasValue)
        return users.SingleOrDefault(
                    user =>
                    user.Username == username &&
                    user.EncryptedPassword == password &&
                    user.StatusID == 1
                    );
    
        return users.SingleOrDefault(
                    user =>
                    user.Username == username &&
                    user.EncryptedPassword == password
                    );
