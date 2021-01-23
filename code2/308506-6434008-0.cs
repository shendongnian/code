        public class SecurityHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var message = getNext()(input, getNext);
            var returnType = message.ReturnValue.GetType();
            if (typeof(IQueryable).IsAssignableFrom(returnType))
            {
                var entityType = returnType.GetGenericArguments().Single();
                var securableAttribute = entityType.GetAttribute<SecurableTypeAttribute>();
                if (securableAttribute != null)
                {
                    //Build expression to filter the list from the attribute and primary key of the entity
                    //Return the new IQueryable
                    message.ReturnValue = AddWhereExpression(
                        (IQueryable)message.ReturnValue, 
                        securableAttribute.FilterValues,
                        securableAttribute.FilterPropertyName);
                }
            }
            return message;
        }
        public int Order { get; set; }
        private static IQueryable AddWhereExpression(IQueryable query, IEnumerable ids, string filterPropertyName)
        {
            // Build this expression:
            // item => ids.Contains(item.[PrimaryKeyPropertyName])
            var itemParameter = Expression.Parameter(query.ElementType, "item");
            var itemParameterProperty = Expression.Property(itemParameter, filterPropertyName);
            var listParameter = Expression.Constant(ids);
            var containsExpression = Expression.Call(
                listParameter,
                typeof(Enumerable).GetMethod("Contains", new[] { query.ElementType }),
                itemParameterProperty);
            var delegateTypeExpression = Expression.GetFuncType(new[] { query.ElementType, typeof(bool) });
            var whereExpression = Expression.Lambda(
                delegateTypeExpression,
                containsExpression,
                new[] { itemParameter }
                );
            return query.Provider.CreateQuery(whereExpression);
        }
    }
