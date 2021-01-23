    var where1 = typeof(Queryable).GetMethods()
                     .Where(x => x.Name == "Where")
                     .Select(x => new { M = x, P = x.GetParameters() })
                     .Where(x => x.P.Length == 2
                                 && x.P[0].ParameterType.IsGenericType
                                 && x.P[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                                 && x.P[1].ParameterType.IsGenericType
                                 && x.P[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
                     .Select(x => new { x.M, A = x.P[1].ParameterType.GetGenericArguments() })
                     .Where(x => x.A[0].IsGenericType
                                 && x.A[0].GetGenericTypeDefinition() == typeof(Func<,>))
                     .Select(x => new { x.M, A = x.A[0].GetGenericArguments() })
                     .Where(x => x.A[0].IsGenericParameter
                                 && x.A[1] == typeof(bool))
                     .Select(x => x.M)
                     .SingleOrDefault();
