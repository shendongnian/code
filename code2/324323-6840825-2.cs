    public static class SortExtension {
      public static Comparison<T> GetComparer<T, TP>(Expression<Func<T, IComparable<TP>>> propertyExpression) {
        if (propertyExpression == null) throw new ArgumentNullException();
        var member = ((propertyExpression.Body is UnaryExpression) ? ((UnaryExpression)propertyExpression.Body).Operand : propertyExpression.Body) as MemberExpression;
        if (member == null) throw new ArgumentException();
        var parameterA = Expression.Parameter(typeof(T), "a");
        var parameterB = Expression.Parameter(typeof(T), "b");
        var nullExpr = Expression.Constant(null);
        var valueA = Expression.Property(parameterA, member.Member.Name);
        var valueB = Expression.Property(parameterB, member.Member.Name);
        var compare = Expression.Call(valueA, typeof(TP).GetMethod("CompareTo", new[] { typeof(TP) }), valueB);
        var checkBPropNull = Expression.Condition(Expression.Equal(valueB, nullExpr), Expression.Constant(0), Expression.Constant(-1));
        var checkAPropertyNull = Expression.Condition(Expression.Equal(valueA, nullExpr), checkBPropNull, compare);
        var checkBNullANot = Expression.Condition(Expression.Equal(parameterB, nullExpr), Expression.Constant(1), checkAPropertyNull);
        var checkBNullANull = Expression.Condition(Expression.Equal(parameterB, nullExpr), Expression.Constant(0), Expression.Constant(-1));
        var checkANull = Expression.Condition(Expression.Equal(parameterA, nullExpr), checkBNullANull, checkBNullANot);
        return (a, b) => Expression.Lambda<Func<T, T, int>>(checkANull, parameterA, parameterB).Compile()(a, b);
      }
      public static void SortBy<T, TP>(this List<T> source, Expression<Func<T, IComparable<TP>>> propertyExpression) {
        if (source == null) throw new ArgumentNullException();
        source.Sort(GetComparer(propertyExpression));
      }
    }
