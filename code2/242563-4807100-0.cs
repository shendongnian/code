    public static void AddOne<S,T>(this S x, Expression<Func<S,T>> expr)
    {
        if (expr.Body.NodeType != ExpressionType.MemberAccess)
            throw new InvalidOperationException();
        MemberExpression memberExpr = expr.Body as MemberExpression;
        switch (memberExpr.Member.MemberType)
        {
            case MemberTypes.Field:
                {
                    FieldInfo field = memberExpr.Member as FieldInfo;
                    ulong value = Convert.ToUInt64(field.GetValue(x));
                    ++value;
                    field.SetValue(x, Convert.ChangeType(value, field.FieldType));
                    break;
                }
            case MemberTypes.Property:
                {
                    PropertyInfo prop = memberExpr.Member as PropertyInfo;
                    ulong value = Convert.ToUInt64(prop.GetValue(x, null));
                    ++value;
                    prop.SetValue(x, Convert.ChangeType(value, prop.PropertyType), null);
                    break;
                }
            default:
                throw new InvalidOperationException();
        }
    }
