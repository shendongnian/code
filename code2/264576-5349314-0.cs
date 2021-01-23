    if(UserNameAlreadyExists(username))
    {
       throw new Exception("Username already exists");
    }
    if(EmailAlreadyExists(email))
    {
       throw new Exception("Email already exists");
    }
