    var sortedByName = productList.OrderBy(NameSelector);
    var sortedByDate = productList.OrderBy(DateCreatedSelector);
    var sortedByCustom = productList.OrderBy(p => p.SomeOtherProperty);
    // ...
    // predefined delegates
    public static readonly Func<Product, string> NameSelector = p => p.Name;
    public static readonly Func<Product, DateTime> DateCreatedSelector =
                                                         p => p.DateCreated;
