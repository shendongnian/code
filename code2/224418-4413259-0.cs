    public static void AddTo(this IEnumerable<Tutorial> source, Tutorial projection)
    {
        if (source.Count() == 0)
            return;
        projection.Title = source.First().Title;
        projection.Author = source.First().Author;
        projection.Date = source.First().Date;
    }
