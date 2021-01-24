    public async Task<IEnumerable<articles>> GetArticlesByStatus(ArticleStatus status)
    {
        var query = await _context.article.AsNoTracking()
            .Where(x => x.ArticleStatusId == (int)status).ToListAsync();
    }
