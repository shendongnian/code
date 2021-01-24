        public async Task<IEnumerable<Article>> GetArticlesByType(ArticleObject request)
    {
        IQueryable<ArticleDTO> foodArticles= null;
        IQueryable<ArticleDTO> drinkArticles= null;
        IQueryable<ArticleDTO> candyArticles= null;
    
        if (request.Food.HasValue && (bool)request.Food)
        {
            foodArticles= _context.Articles.Where(x => x.Active == true && x.ArticleType == ArticleType.Food).Select(x => new Article
            {
                Id = x.Id,
                ArticleName = x.ArticleName
            });
        }
    
        if (request.Drink.HasValue && (bool)request.Drink)
        {
            drinkArticles= _context.Articles.Where(x => x.Active == true && x.ArticleType == ArticleType.Drink).Select(x => new Article
            {
                Id = x.Id,
                ArticleName = x.ArticleName
            });
        }
    
        if (request.Candy.HasValue && (bool)request.Candy)
        {
            // When its candy I want also articles from food category
            candyArticles= _context.Articles.Where(x => x.Active == true && x.ArticleType == ArticleType.Food || x.ArticleType==ArticleType.Candy).Select(x => new Article
            {
                Id = x.Id,
                ArticleName = x.ArticleName
            });
        }
        return await foodArticles.AsQueryable().Union(drinkArticles);
    }
