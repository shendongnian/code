    public IQueryable<System.Collections.Generic.Dictionary<discussion_category, List<discussion_board>>> GetDiscussion_categoriesWithBoards()
    {
        return (GetDiscussion_categories().Select(c =>
            new
            {
                Category = c,
                Boards = GetDiscussion_boardsByCategory(c.ID).ToList()
            }).ToDictionary(i => i.Category, i => i.Boards.ToList())).AsQueryable() as IQueryable<System.Collections.Generic.Dictionary<discussion_category, List<discussion_board>>>;
    }
