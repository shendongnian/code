      public List<T> WhereIn<T, TValue>(IQueryable<T> source, IEnumerable<TValue> keys, Expression<Func<T, TValue>> selector)
      {
         MethodInfo method = null;
         foreach (MethodInfo tmp in typeof(Enumerable).GetMethods(
            BindingFlags.Public | BindingFlags.Static))
         {
            if (tmp.Name == "Contains" && tmp.IsGenericMethodDefinition
                                       && tmp.GetParameters().Length == 2)
            {
               method = tmp.MakeGenericMethod(typeof(TValue));
               break;
            }
         }
         if (method == null) throw new InvalidOperationException(
            "Unable to locate Contains");
         var row = Expression.Parameter(typeof(T), "row");
         var member = Expression.Invoke(selector, row);
         var values = Expression.Constant(keys, typeof(IEnumerable<TValue>));
         var predicate = Expression.Call(method, values, member);
         var lambda = Expression.Lambda<Func<T, bool>>(
            predicate, row);
         return source.Where(lambda).ToList();
      
