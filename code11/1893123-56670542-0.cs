    private async Task<List<NewsDto>> GetCatNews()
    {
        return Entities.GroupBy(e => e.CategoryId)
                   .Select(x => new NewsDto() 
                                   { 
                                      catId = x.Key,
                                      catName = x.First().CategoryName,
                                      NewsContents = x.ToList()
                                   }).ToList();
    }
