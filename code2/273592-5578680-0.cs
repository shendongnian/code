    var query = GetAll(x => x.ToString() == "lala");
    // ...
    public IEnumerable<object> GetAll(Func<object, bool> predicate)
    {
        return AllElements.Where(predicate);
    }
