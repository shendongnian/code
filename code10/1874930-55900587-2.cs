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
        // insert user
        if(InsertSuccessfull)
        {
            // tell sign-in successfull
        }
    }
