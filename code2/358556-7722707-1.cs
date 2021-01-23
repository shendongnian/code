    private ... FillCombobox<T>(...) where T : class, IBaseEntity
    {
        using (var context = new Context())
        {
            var entities = context.CreateObjectSet<T>().ToList();
            ...
            foreach (IBaseEntity entity in entities)
            {
                dt.Rows.Add(entity.Id, entity.Name);
            }
            ...
        }
    }
