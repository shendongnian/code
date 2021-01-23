    static T GetById<T>(object id) where T : EntityObject
    {
        using (var context = new MyEntities())
        {
            return context.CreateObjectSet<T>()
                .SingleOrDefault(t => t.EntityKey.EntityKeyValues[0].Value == id);
        }
    }
