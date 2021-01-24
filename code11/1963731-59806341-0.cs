    public IQueryable<T> CommitLoad<T>(string relations) where T : class
        {
            db.SaveChanges();
            var list = db.Set<T>().AsQueryable();
            if (relations != "")
            {
                string[] rel = relations.Split(";");
                foreach (var item in rel)
                    list = list.Include<T>(item);
            }
            return list;
        }
