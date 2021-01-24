    var result = Base.View.Query<Keyword>(query, inc => inc.Page)
    .GroupBy(g => g.PageId)
        .Select(g => new LinkDTO(
            g.OrderByDescending(o => o.Volume).First().Term.ToLower().HighlightExcept(reservedWords),
            currentUrl.ToAbsolute(g.OrderByDescending(o => o.Volume).First().Page.Path))
