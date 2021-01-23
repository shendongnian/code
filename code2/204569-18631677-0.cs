        public IList<TEntityInterface> Where(Expression<Func<TEntityInterface, bool>> predicate, params string[] includedProperties)
        {
            DbQuery<TEntity> query = Context.Set<TEntity>();
            foreach (string prop in includedProperties)
                query = query.Include(prop);
            return query.Where(predicate).ToList<TEntityInterface>();
        }
