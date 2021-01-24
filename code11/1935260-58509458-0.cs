    public static Post FirstOrDefault(this YourDBType _db, string Key)
    {
        foreach(Post x in _db.Posts)
        {
            if(x.Key == Key)
            {
                return x
            }
        }
        return null
    }
