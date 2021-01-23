    public void LoadProperty<TElement>(T entity, 
            Expression<Func<T, ICollection<TElement>>> navigationProperty,
            Expression<Func<TElement, bool>> predicate) where TElement : class
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity)         
                .Collection(navigationProperty)
                .Query()
                .Where(predicate)
                .Load();
    }
