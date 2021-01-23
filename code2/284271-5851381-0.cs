    public IEnumerable<PropertyInfo> GetProperties()
    {
        Type t = this.GetType();
        return t.GetProperties()
            .Where(p => (p.Name != "EntityKey" && p.Name != "EntityState"))
            .Select(p => p).ToList();
    }
