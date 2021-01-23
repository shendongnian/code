    static class MapCopier
    {
        public static void Copy(IEnumerable<IUntypedField> fields, IFieldMap from, IFieldMap to)
        {
            foreach (var field in fields)
                Copy(field, from, to);
        }
        // cache generated Copy lambdas
        static Dictionary<Type, Action<IUntypedField, IFieldMap, IFieldMap>> copiers =
            new Dictionary<Type, Action<IUntypedField, IFieldMap, IFieldMap>>();
        // generate Copy lambda based on passed-in type
        static void Copy(IUntypedField field, IFieldMap from, IFieldMap to)
        {
            // figure out what type we need to look up;
            // we know we have a Field<TValue>, so find TValue
            Type type = field.GetType().GetGenericArguments()[0];
            Action<IUntypedField, IFieldMap, IFieldMap> copier;
            if (!copiers.TryGetValue(type, out copier))
            {
                // copier not found; create a lambda and compile it
                Type tFieldMap = typeof(IFieldMap);
                // create parameters to lambda
                ParameterExpression
                    fieldParam = Expression.Parameter(typeof(IUntypedField)),
                    fromParam = Expression.Parameter(tFieldMap),
                    toParam = Expression.Parameter(tFieldMap);
                // create expression for "(Field<TValue>)field"
                var converter = Expression.Convert(fieldParam, field.GetType());
                // create expression for "to.Put(field, from.Get(field))"
                var copierExp =
                    Expression.Call(
                        toParam,
                        tFieldMap.GetMethod("Put").MakeGenericMethod(type),
                        converter,
                        Expression.Call(
                            fromParam,
                            tFieldMap.GetMethod("Get").MakeGenericMethod(type),
                            converter));
                // create our lambda and compile it
                copier =
                    Expression.Lambda<Action<IUntypedField, IFieldMap, IFieldMap>>(
                        copierExp,
                        fieldParam,
                        fromParam,
                        toParam)
                        .Compile();
                // add the compiled lambda to the cache
                copiers[type] = copier;
            }
            // invoke the actual copy lambda
            copier(field, from, to);
        }
        public static void Copy<TValue>(Field<TValue> field, IFieldMap from, IFieldMap to)
        {
            to.Put(field, from.Get(field));
        }
    }
