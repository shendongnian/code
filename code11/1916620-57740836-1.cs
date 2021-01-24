    private List<DiagnosticDetails> SortByAllValuesConsistently(List<DiagnosticDetails> diagnosticDetails)
        {
            /*
             diagnosticDetails.OrderBy(detail => detail.Values.ElementAt(0).Value)
                .ThenBy(detail => detail.Values.ElementAt(1).Value))
                .ThenBy(detail => detail.Values.ElementAt(2).Value))
                .ThenBy(detail => detail.Values.ElementAt(3).Value))
                ...
                for each value in detail.Values.
                
             */
            if (diagnosticDetails.IsNullOrEmpty())
                return diagnosticDetails;
            IQueryable<DiagnosticDetails> queryableData = diagnosticDetails.AsQueryable();
            // detail.Values
            ParameterExpression p = Expression.Parameter(typeof(DiagnosticDetails), "detail");
            MemberExpression prVs = Expression.Property(p, "Values");
            // detail.Values.ElementAt(0).
            ConstantExpression c0 = Expression.Constant(0, typeof(int));
            Expression callElAt = expressionTreeHelper.CallElementAt(prVs, c0);
            // detail.Values.ElementAt(0).Value
            MemberExpression prV = Expression.Property(callElAt, "Value");
            // detail => detail.Values.ElementAt(0).Value
            Delegate predicate = Expression.Lambda(prV,p).Compile();
            // diagnosticDetails.OrderBy(detail => detail.Values.ElementAt(0).Value)
            Expression orderByCallExpression = expressionTreeHelper.CallOrderBy(queryableData.Expression, predicate);
            var maxElementsInValues = diagnosticDetails.Select(dd => dd.Values.Count()).Max();
            for (int i = 1; i < maxElementsInValues; i++)
            {
                // detail.Values
                ParameterExpression pi = Expression.Parameter(typeof(DiagnosticDetails), "detail");
                MemberExpression prVsi = Expression.Property(pi, "Values");
                // detail.Values.ElementAt(i).
                ConstantExpression ci = Expression.Constant(i, typeof(int));
                Expression callElAti = expressionTreeHelper.CallElementAt(prVsi, ci);
                
                // detail.Values.ElementAt(i).Value
                MemberExpression prVi = Expression.Property(callElAti, "Value");
                // detail => detail.Values.ElementAt(i).Value
                Delegate predicateI = Expression.Lambda(prVi, pi).Compile();
                // orderByCallExpression.ThenBy(detail => detail.Values.ElementAt(0).Value)
                orderByCallExpression = expressionTreeHelper.CallThenBy(orderByCallExpression, predicateI);
            }
            // Get result
            var orderedList = (Func<IOrderedEnumerable<DiagnosticDetails>>)Expression.Lambda(orderByCallExpression).Compile();
            
            return orderedList().ToList();
        }
    /// <remarks>
    /// Look at https://stackoverflow.com/questions/326321/how-do-i-create-an-expression-tree-calling-ienumerabletsource-any for more details
    /// </remarks>
    public class ExpressionTreeHelper : IExpressionTreeHelper
    {
        public Expression CallElementAt(Expression collection, ConstantExpression constant)
        {
            Type cType = GetIEnumerableImpl(collection.Type);
            collection = Expression.Convert(collection, cType);
            Type elemType = cType.GetGenericArguments()[0];
            // Enumerable.ElementAt<T>(IEnumerable<T>, int index)
            MethodInfo elementAtMethod = (MethodInfo)GetGenericMethod(
                typeof(Enumerable),
                "ElementAt",
                new[] { elemType },
                new[] { collection.Type, constant.Type }, BindingFlags.Static);
            return Expression.Call(
                elementAtMethod,
                collection,
                constant);
        }
        public Expression CallOrderBy(Expression collection, Delegate predicate)
        {
            Type cType = GetIEnumerableImpl(collection.Type);
            collection = Expression.Convert(collection, cType);
            Type elemType = cType.GetGenericArguments()[0];
            Type predType = typeof(Func<,>).MakeGenericType(elemType, predicate.Method.ReturnType);
            // Enumerable.OrderBy<TSource, TKey>(IEnumerable<TSource>, Func<TSource,TKey>)
            MethodInfo orderByMethod = (MethodInfo)
                GetGenericMethod(
                    typeof(Enumerable),
                    "OrderBy",
                    new[] { elemType, predicate.Method.ReturnType },
                    new[] { cType, predType }, BindingFlags.Static);
            return Expression.Call(
                orderByMethod,
                collection,
                Expression.Constant(predicate));
        }
        public Expression CallThenBy(Expression collection, Delegate predicate)
        {
            Type inputType = GetIEnumerableImpl(collection.Type);
            Type elemType = inputType.GetGenericArguments()[0];
            Type predType = typeof(Func<,>).MakeGenericType(elemType, predicate.Method.ReturnType);
            // ! important convert to IOrderedEnumerable
            Type cType = typeof(IOrderedEnumerable<>).MakeGenericType(new Type[] { elemType });
            collection = Expression.Convert(collection, cType);
            // Enumerable.CallThenBy<TSource, TKey>(IEnumerable<TSource>, Func<TSource,TKey>)
            MethodInfo thenByMethod = (MethodInfo)
                GetGenericMethod(
                    typeof(Enumerable),
                    "ThenBy",
                    new[] { elemType, predicate.Method.ReturnType },
                    new[] { cType, predType }, BindingFlags.Static);
            return Expression.Call(
                thenByMethod,
                collection,
                Expression.Constant(predicate));
        }
        private MethodBase GetGenericMethod(Type type, string name, Type[] typeArgs, Type[] argTypes, BindingFlags flags)
        {
            int typeArity = typeArgs.Length;
            var methods = type.GetMethods()
                .Where(m => m.Name == name)
                .Where(m => m.GetGenericArguments().Length == typeArity)
                .Select(m => m.MakeGenericMethod(typeArgs));
            return Type.DefaultBinder.SelectMethod(flags, methods.ToArray(), argTypes, null);
        }
        private bool IsIEnumerable(Type type)
        {
            return type.IsGenericType
                   && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
        private Type GetIEnumerableImpl(Type type)
        {
            // Get IEnumerable implementation. Either type is IEnumerable<T> for some T, 
            // or it implements IEnumerable<T> for some T. We need to find the interface.
            if (IsIEnumerable(type))
                return type;
            Type[] t = type.FindInterfaces((m, o) => IsIEnumerable(m), null);
            Debug.Assert(t.Length == 1);
            return t[0];
        }
    }
