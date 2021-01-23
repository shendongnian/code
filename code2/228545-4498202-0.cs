    private static Type[] _factory = new Type[(int)FeedType.Total];
    public void RegisterFeed(FeedType feedType, Type type)
    {
      ...
      _factory[(int)feedType] = type;
      ...
    }
    public Feed GetFeed(FeedType feedType)
    {
        return Activator.CreateInstance(_factory[(int)feedType]) as Feed;
    }
