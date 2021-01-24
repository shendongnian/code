         object[,] arrayTest = new object[3, 2];
         
         arrayTest[0, 0] = "Field1";
         arrayTest[1, 0] = "X1";
         arrayTest[2, 0] = "derp";
         
         arrayTest[0, 1] = "Field2";
         arrayTest[1, 1] = "X2";
         arrayTest[2, 1] = "Y2";
         
         var anonType = RunTimeType.Create(arrayTest);
         
         var anonList = ( IList)RunTimeType.CreateGenericList(anonType, arrayTest);
         
         
         
         
         // define the Type of the Filter Func<anontype,bool>
         Type filterType = typeof(Func<,>).MakeGenericType(anonType, typeof(bool));
         
         
         // Build a simple filter expression
         ParameterExpression parameter = Expression.Parameter(anonType, "item");
         
         
         var property = anonType.GetProperty("Field1");
         MemberExpression member = Expression.Property(parameter, property);
         
         
         BinaryExpression euqalExpression = Expression.Equal(member, Expression.Constant("derp"));
         
         MethodInfo whereMethod = typeof(Enumerable).GetMethods().Single(m =>
         {
             if (m.Name != "Where" || !m.IsStatic)
                 return false;
             ParameterInfo[] parameters = m.GetParameters();
             return parameters.Length == 2 && parameters[1].ParameterType.GetGenericArguments().Length == 2;
         });
         MethodInfo finalMethod = whereMethod.MakeGenericMethod(anonType);
         LambdaExpression filterExpression = Expression.Lambda(filterType, euqalExpression, parameter);
         
         
         
         Delegate filter = filterExpression.Compile();
         
         
         Console.WriteLine("This is the Filter: {0}", filterExpression);
         
         IEnumerable result = (IEnumerable) finalMethod.Invoke(null, new object[] {anonList, filter});
         
         foreach (dynamic o in result)
         {
             Console.WriteLine(o.Field1);
         }
         
         Console.ReadKey();
