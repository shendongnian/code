    public static bool MeetsCriteria(object data)
    {
        Type type = typeof(data);
        IEnumerable<Predicate<object>> predicates = typePredicateMap.Where(kvp => type.IsInstanceOfType(data)).Select(kvp => kvp.Value);
        bool isValid = true;
        foreach (var predicate in predicates)
        {
            isValid &= predicate(data);
        }
        return isValid;
    }
