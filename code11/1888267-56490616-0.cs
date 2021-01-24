c#
        public virtual T GetById(int id)
        {
            return DataContext.Set<T>().AsNoTracking().FirstOrDefault(m => m.Id == id);
        }
