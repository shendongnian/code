    var result = query.GroupBy(x => new
        {
            x.BookName,
            x.PublisherName
        })
        .Select(x => new
        {
            x.Key.BookName,
            x.Key.PublisherName,
            AuthorName = string.Join(", ", x.Select(y => y.AuthorName))
        });
