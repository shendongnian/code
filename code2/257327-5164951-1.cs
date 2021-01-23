    Dictionary<string, Func<IEnumerable<Question>, IEnumerable<Question>> orderings =
        new Dictionary<string, Func<IEnumerable<Question>, IEnumerable<Question>>()
    {
        { "Id",  questions => questions.OrderBy(x => x.Id) },
        { "Title",  questions => questions.OrderBy(x => x.Title) },
        { "Answer",  questions => questions.OrderBy(x => x.Answer) },
        { "Id Desc",  questions => questions.OrderByDescending(x => x.Id) },
        { "Title Desc",  questions => questions.OrderByDescending(x => x.Title) },
        { "Answer Desc",  questions => questions.OrderByDescending(x => x.Answer) },
    };
