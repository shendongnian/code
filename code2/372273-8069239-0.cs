    public static Expression<Func<Item, bool>> IsKnownByIn(string[] query )
    {
    var i = PredicateBuilder.False<Item>();
    foreach (string keyword in query)
    {
        string temp = keyword;
        i = i.Or(p=> p.Name.Contains(temp) || p.ID.ToString().Contains(temp));
    }
    return i;
}
