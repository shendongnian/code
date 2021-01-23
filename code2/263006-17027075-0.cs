    public Articles GetByName(string name, Categories category, Companies company)
            {
        var query = from article in session.Linq<Articles>()
                                where string.Equals(article.Name, StringComparison.CurrentCultureIgnoreCase)  == name &&
                                    string.Equals(article.Category, StringComparison.CurrentCultureIgnoreCase == category &&
                                    string.Equals(article.Company, StringComparison.CurrentCultureIgnoreCase == company
                                select article;
    
                    return query.FirstOrDefault();
    }
