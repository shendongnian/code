    public static class LinqExtensions
    {
        public static Expression<Func<IGrouping<int, TInput>, TOutput>> AggregateExpression<TInput, TOutput>(string[] strings) where TInput: new()
        {
            ParameterExpression p = Expression.Parameter(typeof(IGrouping<int, TInput>));
            // Create object using Member Initialization; for example `new XXX { A = a.Sum(b => b.A), B = a.Sum(b => b.B) }`
            MemberInitExpression body = Expression.MemberInit(
                Expression.New(typeof(TOutput).GetConstructor(Type.EmptyTypes)),
                strings.Select(CreateMemberAssignment).ToArray()
            );
            // Create lambda
            return Expression.Lambda<Func<IGrouping<int, TInput>, TOutput>>(body, p);
            // Create single member assignment for MemberInit call
            // For example for expression `new XXX { A = a.Sum(b => b.A), B = a.Sum(b => b.B) }` it can be `A = a.Sum(b => b.A)` or `B = a.Sum(b => b.B)`
            MemberAssignment CreateMemberAssignment(string prop)
            {
                // If needed you can map TInput.Prop to TOutput.Prop names here
                PropertyInfo propInfo = typeof(TOutput).GetProperty(prop);
                
                return Expression.Bind(
                    propInfo,
                    Expression.Convert(
                        Expression.Call(
                            typeof(Enumerable),
                            "Sum",
                            new[] {typeof(TInput)},
                            new[] {p, CreateSumLambda(prop)}
                        ),
                        propInfo.PropertyType
                    )
                );
            }
            
            // Create Lambda to be passed to Sum method
            Expression CreateSumLambda(string prop)
            {
                ParameterExpression q = Expression.Parameter(typeof(TInput));
                return Expression.Lambda(Expression.Property(q, prop), q);
            }
        }
    }
