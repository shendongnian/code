    public bool HasValidationErrors()
    {
        return GetValidationErrors().Any();
    }
    
    public IEnumerable<string> GetValidationErrors()
    {
        if (/* Some Condition */)
        {
            yield return "condition 1 not met";
        }
    
        if (/* Some Condition */)
        {
            yield return "condition 2 not met";
        }
    
        yield break;
    }
