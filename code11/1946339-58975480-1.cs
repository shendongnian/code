            ParameterExpression ctx = Expression.Parameter(typeof(Context), "ctx");
            ParameterExpression product = Expression.Parameter(typeof(Product), "product");
            LambdaExpression lambdaExpr = Expression.Lambda(
                /* your actual code, depending on what you want to do */
                    Expression.Add(
                    ctx,
                    Expression.Constant(1)
                ),
                new List<ParameterExpression>() { ctx, product })
