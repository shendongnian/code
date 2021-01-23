    public IQueryable<Dictionary<discussion_category, List<discussion_board>>>
    GetDiscussion_categoriesWithBoards()
    {
        return new[] {
            GetDiscussion_categories().Select(c => new {
                Category = c,
                Boards = GetDiscussion_boardsByCategory(c.ID).ToList()
            }).ToDictionary(i => i.Category, i => i.Boards.ToList())
        }.AsQueryable();
    }
