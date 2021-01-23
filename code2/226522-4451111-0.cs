    return (topics.Select(c => new TopicUi
    {
        Bookmarks = new List<Bookmark> {
          new Bookmark { Id = c.BookmarkId, Name = c.BookmarkName }
        }
    })).ToList();
