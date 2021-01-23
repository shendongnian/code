    public UniqueEmailAttribute()
        : base("The value for '{0}' is already taken")
    {
    }
    public override bool IsValid( object value )
    {
        string toCheck = value as string;
        if( String.IsNullOrEmpty(toCheck) ) return false;
        return ( DataRepository.GetMembersByEmail(toCheck).Count() == 0 );
    }
    [Inject]
    public IDataRepository DataRepository { get; set; }
