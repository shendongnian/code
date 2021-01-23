    public IEnumerable<CustomVariableGroup> GetAll()
    {
        using (IDocumentSession session = Database.OpenSession())
        {
            IEnumerable<CustomVariableGroup> groups = session.Query<CustomVariableGroup>();
            return groups.ToList();
        }
    }
