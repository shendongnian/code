    public async Task<ActionResult<List<CategoryDTO>>> Get()
    {
        return await _testContext.Category
            .Select(cat => new CategoryDTO
            {
                CategoryId = cat.CategoryId,
                Title = cat.Title,
                Subjects = cat.Subject.Select(sub => sub.Title).ToList()
            })
            .ToListAsync();
    }
