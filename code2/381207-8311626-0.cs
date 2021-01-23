    public IEnumerable<UserLink> GetLinks()
    {
        yield return new UserLink() { Name = "A", ... };
        yield return new UserLink() { Name = "B", ... };
        ...
    }
