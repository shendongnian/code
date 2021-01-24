    private string lastname;  // backing field
    public string LastName
    {
        get => lastName;
        set
        {
            lastname = value.TrimAndReduce();
        }
    }
