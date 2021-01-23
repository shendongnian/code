    public static void Admonish(this IEnumerable<Naughty> followers)
    {
        foreach(var follower in followers) { follower.Preach(); }
    }
    public static void Admonish(this IEnumerable<Obedient> followers)
    {
        foreach(var follower in followers) { follower.Preach(); }
    }
