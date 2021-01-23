    public static class PropertyExtensions
    {
        public static PrimitivePropertyConfiguration Property<TClass, TProperty>(this EntityTypeConfiguration<TClass> etc, string propertyName)
            where TClass : class
            where TProperty : struct
        {
            PrimitivePropertyConfiguration returnValue;
            Type type = typeof(TClass);
    
            var propertyInfo = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    
            ParameterExpression parameterExpression = Expression.Parameter(type, "xyz");
            MemberExpression memberExpression = Expression.Property((Expression)parameterExpression, propertyInfo);
    
            if (IsNullable(memberExpression.Type))
            {
                returnValue = etc.Property((Expression<Func<TClass, TProperty?>>)Expression.Lambda(memberExpression, parameterExpression));
            }
            else
            {
                returnValue = etc.Property((Expression<Func<TClass, TProperty>>)Expression.Lambda(memberExpression, parameterExpression));
            }
    
            return returnValue;
        }
    
        private static bool IsNullable(Type type)
        {
            bool result;
    
            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                result = genericType.Equals(typeof(Nullable<>));
            }
            else
            {
                result = false;
            }
    
            return result;
        }
    }
