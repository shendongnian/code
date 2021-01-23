    public GetAllPostsAndAnswersForThisMonth()
    {
        using (var context = new MyEntities())
        {
            return context.Posts.Include("Answers")
                       .Where(p => p.UserID == UserID)
                       .ToList();
        }
    }
