    private EntitySet<Person> _Friends;
    [Association(Storage = "_Friends", OtherKey = "PersonID")]
    public EntitySet<Person> Friends
    {
        get { return this._Friends; }
        set { this._Friends.Assign(value); }
    }
