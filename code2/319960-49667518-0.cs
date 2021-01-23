    public MissingEntityException(Type type, string criteria, string message = "") 
        : this(type, criteria, message, null)
    {           
    }
    public MissingEntityException(Type type, string criteria, string message, Exception innerException) 
         : base(message, innerException) 
    {
        this.EntityType = type;
        this.Criteria = criteria;
    }
