    if(string.IsNullOrEmpty(username))
    {
        // tell username is empty
    }
    else if(string.IsNullOrEmpty(password))
    {
        // tell password is empty
    }
    else if(password != passwordConfirmation)
    {
        // tell passwords do not match
    }
    else if(UserAlreadyExists(username))
    {
        // tell username is taken
    }
    else
    {
        if(InsertUser(username, password))
        {
            // tell sign-in successfull
        }
    }
    private bool UserAlreadyExists(string username)
    {
        // use SELECT parameterized query
        // return user existance (true or false)
    }
    private bool InsertUser(string username, string password)
    {
        // use INSERT parameterized query
        // return success (true or false)
    }
