    public void Apply(int jobId, int userId)
    {
        // Validate the IDs.
    
        // Construct the entities.
        var job = ...;
        var user = ...;
    
        // Call the 'proper' overload.
        Apply(job, user);
    }
    
    public void Apply(Job job, User user)
    {
        // Actual business logic belongs here.
    }
