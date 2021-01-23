            // hang on to row[string] property 
            var indexerProperty = typeof(SqlDataReader).GetProperty("Item", new[] { typeof(string) });
            // list of statements in our dynamic method
            var statements = new List<Expression>();
            // store instance for setting of properties
            ParameterExpression instanceParameter = Expression.Variable(typeof(T));
            ParameterExpression sqlDataReaderParameter = Expression.Parameter(typeof(SqlDataReader));
            // create and assign new T to variable: var instance = new T();
            BinaryExpression createInstance = Expression.Assign(instanceParameter, Expression.New(typeof(T)));
            statements.Add(createInstance);
            foreach (var property in typeof(T).GetProperties())
            {
                // instance.MyProperty
                MemberExpression getProperty = Expression.Property(instanceParameter, property);
                // row[property] -- NOTE: this assumes column names are the same as PropertyInfo names on T
                IndexExpression readValue = Expression.MakeIndex(sqlDataReaderParameter, indexerProperty, new[] { Expression.Constant(property.Name) });
                // instance.MyProperty = row[property]
                BinaryExpression assignProperty = Expression.Assign(getProperty, Expression.Convert(readValue, property.PropertyType));
                
                statements.Add(assignProperty);
            }
            var returnStatement = instanceParameter;
            statements.Add(returnStatement);
            var body = Expression.Block(instanceParameter.Type, new[] { instanceParameter }, statements.ToArray());
            /* so we end up with
             * T Read(SqlDataReader row)
             * {
             * var x = new T();
             * x.Prop1 = (cast)row["Prop1"]
             * x.Prop2 = (cast)row["Prop2"]
             * x.Prop3 = (cast)row["Prop3"]
             * x.Prop4 = (cast)row["Prop4"]
             * etc.
             * return x
             * }
             */
            var lambda = Expression.Lambda<Func<SqlDataReader, T>>(body, sqlDataReaderParameter);
            // cache me!
            return lambda.Compile();
    
