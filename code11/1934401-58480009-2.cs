    private IEnumerable<SelectListItem> GetCategories()
    {
        var categories = _context.CategoryModels
                        .Select(c => new SelectListItem
                        {
                           Value = c.ID.ToString(),
                           Text = c.Value
                        });
    
         return categories;
     }
