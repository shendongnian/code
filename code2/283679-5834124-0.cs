    public long CreateUser(string userName)
    {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentNullException();
    
            ...
    }
