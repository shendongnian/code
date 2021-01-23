    Func<YourCType, IList<Bookmark>> createListFunc = (c) => 
    { 
        var list = new List(); 
        list.Add(new Bookmark { Id = c.BookmarkId, Name = c.BookmarkName 
        return list;
    });
    return (topics.Select(c => new TopicUi()
    {
        Bookmarks = createListFunc(c)
    })).ToList();
