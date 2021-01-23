    [Flags]
    public enum PredicateOption
    {
        IsCaseSensitive, IsRegularExpression, IsMultipleTerms
    };
...
    public Dictionary<PredicateOption, Func<SearchResult, bool>> _predicates
        = new Dictionary<PredicateOption, Func<SearchResult, bool>>();
    _predicates.Add(PredicateOption.IsCaseSensitive, result => Search(result.Name));
    _predicates.Add(PredicateOption.IsCaseSensitive | PredicateOption.IsMultipleTerms,
        result => SearchCaseInsensitiveMultiple(result.Name));
