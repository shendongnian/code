    // Start with a method that takes a predicate and retrieves the property names
    static IEnumerable<string> GetColumnNames<T>(Expression<Func<T,bool>> predicate)
    {
        // Use Expression.Body to gather the necessary details
        var members = GetMemberExpressions(predicate.Body);
        if (!members.Any())
        {
            throw new ArgumentException(
                "Not reducible to a Member Access", 
                "predicate");
        }
        return members.Select(m => m.Member.Name);
    }
