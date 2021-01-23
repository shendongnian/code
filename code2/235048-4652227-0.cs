    Article art = new Article
    {
        Title = "title"
    };
    
    art.SectionID = 0;
        
    if (art.EntityState == EntityState.Detached)
    {
       Articlerctx.AddToArticles(art);
    }
