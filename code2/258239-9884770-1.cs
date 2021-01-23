    public void CheckSecurity()
    {
        if ((this.UserName == null || this.Password == null) ||
            this.UserName == "username" && this.Password == "password"))
        {
            throw new FaultException("Unknown username or incorrect password.");
        }
    }
