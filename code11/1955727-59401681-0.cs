c#
    public static Expression<Func<Persons,SelectObjDTO>> SelectorFunc { get; } = POCO =>
        new SelectObjDTO()
        {
            Id = POCO.Users.FirstOrDefault().Id,
            FirstName= POCO.DocumentNumber+ " - " + POCO.FirstName + " " + POCO.LastName
        };
    public static Func<Persons,SelectObjDTO> Selector  { get; } = SelectorFunc.Compile();
    public static IEnumerable<SelectObjDTO> ToSelectObjDTO(this IEnumerable<Persons> Query)
        => Query.Select(SelectorFunc);
