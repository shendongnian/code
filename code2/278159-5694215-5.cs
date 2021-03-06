        public static string GetPropertyColumn<T>(Expression<Func<T,object>> f)
        {
            Type t = typeof(T);
            MemberExpression memberExpression = null;
            if (f.Body.NodeType == ExpressionType.Convert)
            {
                memberExpression = ((UnaryExpression)f.Body).Operand as MemberExpression;
            }
            else if (f.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = f.Body as MemberExpression;
            }
            string name = memberExpression.Member.Name;
            System.Reflection.FieldInfo fi = t.GetField(name);
            object[] attrs = fi.GetCustomAttributes(true);
            return attrs.Count() > 0 ? "Some attributes exists" : "There is no attributes";
        }
