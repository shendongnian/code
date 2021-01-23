    public Post Select(int id)
    {
        MyDataContext dc = MyDataContext.Create();
        return dc.Posts.Single(p => p.PostID == id);
    }
