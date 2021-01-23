    public property List<Friendship> {
        session.Query<Friendship>()
            .Where(f => 
                f.User1 != null && f.User2 != null
                && (f.User1 == this || f.User2 == this)
            ).Cacheable()
            .ToList();
    }
