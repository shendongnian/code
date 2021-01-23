    interface IRepository<TPersistant>
    {
          void Save(TPersistant item);
          void Delete(TPersistant item);
          TPersistant Find(Expression<Func<TPersistant,bool>> predicate); 
          // maybe findOne or findMany
          // maybe something like this
          IQueryable<TPersistant> Query();
          /* Other stuff like updating, transactions, commiting, etc.*/
    }
