    MyDbContext db = new MyDbContext();
    public Story Get(int storyId)
    {
        var lazyStory = db.Stories.SingleOrDefault(s => s.Id == storyId);
        var unproxied = db.UnProxy(lazyStory);
        return unproxied;
    }
