    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public bool Add(T item)
    {
        return this.AddIfNotPresent(item);
    }
 
