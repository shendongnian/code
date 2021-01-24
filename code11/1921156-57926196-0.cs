    using (var ctx = new DataContext())
    {
        // load the whole hierarchy to memory
        var q = ctx.Users.Include(u => u.Users).ToList();
        var user = q.Single(u => u.Id == 1);
        Console.WriteLine(string.Join(",", GetIds(user)));
    }
    
    private static IEnumerable<int> GetIds(User user)
    {
        foreach (var child in user.Users)
            foreach (int id in GetIds(child))
                yield return id;
    
        yield return user.Id;
    }
