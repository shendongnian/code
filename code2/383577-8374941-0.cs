    var articles = context.Articles.Where(a => a.Id != articleId)
                 .OrderBy(p => SafeGetName(p.Categories.OrderBy(q => q.Name).FirstOrDefault())).ToList();
    			 
    private string SafeGetName(Category category)
    {
    	return category != null ? category.Name : null;
    }
