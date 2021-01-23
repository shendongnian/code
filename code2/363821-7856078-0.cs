    IQueryable<Foo> query = ...;
    switch (orderByParameter)
    {
        case "price":
            query = query.OrderBy(x => x.Price);
            break;
        case "rating":
            query = query.OrderBy(x => x.Rating);
            break;
        // etc
    }
