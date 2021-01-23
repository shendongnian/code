    Article[] ArticlesBySameAuthors(Article article)
    {
        return
            (from a in articles
            where a.ArticleID = article.ArticleID
            join articleAuthor in articleAuthors on a.ArticleID equals articleAuthor.ArticleID
            join articleAuthor2 in articleAuthors on articleAuthor.AuthorID equals articleAuthor2.AuthorID
            join article2 in articles on articleAuthor2.ArticleID = article2.ArticleID
            where article2.ArticleID != article.ArticleID
            select article2).ToArray();
    }
