    private String UserIDString { get; set; }
    public Guid UserID
    {
        get
        {
            return new Guid(UserIDString);
        }
        private set
        {
            UserID = value;
        }
    }
