    public static Expression<Func<T, bool>> AddFilterToStringProperty2<T>(
                            Expression<Func<T, string>> expression, string filter, FilterType type)
        {
            var vNotNullExpresion = Expression.NotEqual(
                                    expression.Body,
                                    Expression.Constant(null));
            var vMethodExpresion = Expression.Call(
                    expression.Body,
                    type.ToString(),
                    null,
                    Expression.Constant(filter));
            var vFilterExpresion = Expression.AndAlso(vNotNullExpresion, vMethodExpresion);
            return Expression.Lambda<Func<T, bool>>(
                vFilterExpresion,
                expression.Parameters);
        }
