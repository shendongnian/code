    public DateTime? Dealine{get; set;}
    public bool HasDeadline
    {
        get
        {
            return (Deadline != null);
        }
    }
