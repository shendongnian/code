    private object _activityId; // Yes, object :)
    public Guid ActivityId {
        get { return (Guid)_activityId; }
        set { _activityId = value; }
    }
