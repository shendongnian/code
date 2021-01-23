     private static string GetTableName<T>() where T : EntityObject
        {
            Type type = typeof(T);
            var at = GetAttribute<EdmEntityTypeAttribute>(type);
            return at.Name;
        }
        private static string GetColumnName<T>(Expression<Func<T, object>> propertySelector) where T : EntityObject
        {
            Contract.Requires(propertySelector != null, "propertySelector is null.");
            PropertyInfo propertyInfo = GetPropertyInfo(propertySelector.Body);
            DataMemberAttribute attribute = GetAttribute<DataMemberAttribute>(propertyInfo);
            if (String.IsNullOrEmpty(attribute.Name))
            {
                return propertyInfo.Name;
            }
            return attribute.Name;
        }
        private static T GetAttribute<T>(MemberInfo memberInfo) where T : class
        {
            Contract.Requires(memberInfo != null, "memberInfo is null.");
            Contract.Ensures(Contract.Result<T>() != null);
            object[] customAttributes = memberInfo.GetCustomAttributes(typeof(T), false);
            T attribute = customAttributes.Where(a => a is T).First() as T;
            return attribute;
        }
        private static PropertyInfo GetPropertyInfo(Expression propertySelector)
        {
            Contract.Requires(propertySelector != null, "propertySelector is null.");
            MemberExpression memberExpression = propertySelector as MemberExpression;
            if (memberExpression == null)
            {
                UnaryExpression unaryExpression = propertySelector as UnaryExpression;
                if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
            }
            if (memberExpression != null && memberExpression.Member.MemberType == MemberTypes.Property)
            {
                return memberExpression.Member as PropertyInfo;
            }
            throw new ArgumentException("No property reference was found.", "propertySelector");
        }
