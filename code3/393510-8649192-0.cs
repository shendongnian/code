    private SelectList GetList<T>(IRepository repository, int id, string name)
        where T : IIdentifiable, new()
    {
        List<IIdentifiable> list = repository.All().ToList();
        list.Insert(0, new T() { Name = name, Id = id });
        var statusSelectList = new SelectList(list, "Id", "Name", id);
    }
