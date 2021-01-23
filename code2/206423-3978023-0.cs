    foreach (var u in items)
    {
        if (outputNeed.Contains(u.Key)) {
            outputNeed[u.Key].Add(u.Value);
        }
        else {
            Collection<User> a=new Collection<User>();
            a.Add(u.Value);
            outputNeed.Add(u.Key,a);
        }
    }
