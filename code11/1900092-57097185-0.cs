    public static class ExpressionExtensions
        {
            public static Expression ElvisOperator(this Expression expression, string propertyOrField)
            {
                return Expression.Condition(Expression.NotEqual(expression, Expression.Constant(null)),
                    Expression.PropertyOrField(expression, propertyOrField),
                    Expression.Constant(null, expression.Type)
                    );
            }
        }
