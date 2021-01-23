    ... GetAllPostsForThisMonth(bool includeAnswers)
    {
        using (var context = new MyEntities())
        {
            context.ContextOptions.LazyLoadingEnabled = false;
            // code to get all posts for this month here
            var posts = ...;
            foreach (var post in posts)
                if (!post.Answers.IsLoaded)
                    post.Answers.Load();
            return posts;
        }
    }
