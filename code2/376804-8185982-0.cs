    // This gets filled from the db somehow.
    private IList<WorkLocation> workLocations;
    
    // IEnumerable so that all external additions and
    // removals must go through dedicated methods.
    public IEnumerable<WorkLocation> WorkLocations
    {
        get { return workLocations; }
    }
    
    public void AddWorkLocation(WorkLocation locationToAdd)
    {
        workLocations.Add(locationToAdd);
        // Do whatever else you need to, i.e. mark the item for saving.
    }
    
    public void RemoveWorkLocation(WorkLocation locationToRemove)
    {
        workLocations.Remove(locationToRemove);
        // Do whatever else you need to, i.e. mark the item for saving.
    }
