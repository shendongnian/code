        private Expression GetDeepProperty(Expression parameter, string property)
        {
            var props = property.Split('.');
            var type = parameter.Type;
            var expr = parameter;
            foreach (var prop in props)
            {
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            return expr;
        }
