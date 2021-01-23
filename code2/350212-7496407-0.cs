    // In ArticleRepository...
    public void Save(Article article)
    {
        // IsTransient (as opposed to IsPersistant) means "has not yet been saved"...
        if (article.IsTransient)
        {
            DB.InsertArticle(article);
            // Inserting the article also inserts any comments / sub components...
        }
        else
        {
            // IsDirty means "has been modified since it was taken from the DB"...
            if (article.IsDirty)
            {
                DB.UpdateArticle(article);
            }
            foreach(var comment in article.Comments)
            {
                if(comment.IsTransient)
                {
                    DB.InsertComment(article.Id, comment);
                }
                else
                {
                    if (comment.IsDirty)
                    {
                        DB.UpdateComment(comment);
                    }
                }
            }
        }
    }
