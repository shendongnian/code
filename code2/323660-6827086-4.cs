    using (var ctx = new MyContext())
    {
        Article article = ctx.Articles.Single(a => a.Id == articleId);
        Tag tag = ctx.Tags.SingleOrDefault(t => t.UrlSlug == tagUrl);
        if (tag == null) 
        {
           tag = new Tag() { ... }
           ctx.Tags.AddObject(tag);
        }
        article.Tags.Add(tag);
        ctx.SaveChanges();
    }
