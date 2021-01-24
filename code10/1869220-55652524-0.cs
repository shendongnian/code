    public static Expression<Func<IGrouping<int, Article>, ArtDto>> SelectExpression()
    {
        return x => new ArtDto
        {
            No = x.Select(c => c.NUMBER).FirstOrDefault(),
            UserName = x.Key,
            Count = x.Count()
        };
    }
