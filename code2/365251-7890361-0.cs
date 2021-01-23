    public static IEnumerable<User> ApplyOrdering(this IEnumerable<User> users, params Func<User, string>[] sorts) 
    {     
        users = users.OrderBy(sorts[0]);
        for(int i = 1; i < sorts.length; i++)
        {
            users.ThenBy(sorts[i]);
            i++;
        }
        return users; 
    } 
