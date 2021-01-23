        public static string GetPropertyName<T>(Expression<Func<T, object>> e)
        {
            if (e.Body is MemberExpression)
                return ((MemberExpression)e.Body).Member.Name;
            else if (e.Body is UnaryExpression)
                return ((MemberExpression)((UnaryExpression)e.Body).Operand).Member.Name;
            throw new ArgumentException("Expression must represent field or property access.", "e");
        }
