    public static DateTime? MaxTimeStamp(IEnumerable<T> entities) 
        where T : IHaveTimeStamp
    {
        // Return the max.
        return entities.Select(e => (DateTime?) e.TimeStamp).Max();
    }
