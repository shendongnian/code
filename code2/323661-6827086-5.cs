    using (var ctx = new MyContext())
    {
        Article article = new Article() { Id = articleId };
        ctx.Articles.Attach(article);
        Tag tag = ctx.Tags.SingleOrDefalut(t => t.UrlSlug == tagUrl);
        if (tag == null) 
        {
           tag = new Tag() { ... }
           ctx.Tags.AddObject(tag);
        }
        article.Tags.Add(tag);
        ctx.SaveChanges();
    }
