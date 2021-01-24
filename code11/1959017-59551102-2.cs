    public virtual void SetCredentials(
      string email, string plainTextPassword)
    {
        EMail = email;
        SetPassword(plainTextPassword);
    }
    public virtual void SetPassword(string plainTextPassword)
    {
        HashedPassword = _passwordHasher.HashPassword(
          EMail, plainTextPassword);
    }
