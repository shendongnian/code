    class SearchQuery
    {
        public ICollection<string> Include { get; private set; }
        public ICollection<string> Exclude { get; private set; }
    }
    [...]
    SearchQuery query = new SearchQuery
    {
        Include = { "Foo" }, Exclude = { "Bar" }
    }
    var results = from x in database.Table
                  where query.Include.All(i => x.Subject.Contains(i)) &&
                        query.Exclude.All(i => !x.Subject.Contains(i))
                  select x;
