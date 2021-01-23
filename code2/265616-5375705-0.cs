    [WebGet]
    public List<Stuff> GetStuff()
    {
        var context = new TestDb();
        return context.Stuff.ToList();
    }
