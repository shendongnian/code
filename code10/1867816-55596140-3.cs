    public T Update(TDBTable entity, Expression<Func<TDBTable, object>> expression, object value,
            Expression<Func<TDBTable, bool>> predicate)
    {
         var dbEntity = await GetOneAsync(predicate); // Which fetches me the entity to change
         // Sets the variable
         SetEntityValue(result, expression, value);
         // Update Entity
         result = await EditAsync(result);
         return entity;
    }
