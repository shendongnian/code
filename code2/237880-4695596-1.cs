    private string password;
    
    public string ClearPassword { set { this.password = value; }
    public string EncryptedPassword
    {
       get { return Encrypt(password); }
    }
