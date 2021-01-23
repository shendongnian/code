    [ServiceKnownType(typeof(ErrorResponse))] 
    public BasicResponse RegisterNewUser(UserDTO newUser)
    {
        return new ErrorResponse()
        {
            status = "ERR_USER_NAME",
            errorMsg = "Invalid user name."
        };
    }
