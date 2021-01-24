    public IQueryable<T> CommitLoad<T>() where T : class
        {
            db.SaveChanges();
            var list = db.Set<T>().AsQueryable();
            var key = db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            var foreignkeys = key.GetContainingPrimaryKey().GetReferencingForeignKeys();
            if (foreignkeys.Count() > 0)
            {
                foreach (var item in foreignkeys)
                    list = list.Include<T>(item.DeclaringEntityType.DisplayName());
            }
            return list;
        }
