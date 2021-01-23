        public static string ExampleFunction<T>(Expression<Func<T, string>> f)
        {
            Type t = typeof(T);
            System.Reflection.FieldInfo fi = t.GetField((f.Body as MemberExpression).Member.Name);
            object[] attrs = fi.GetCustomAttributes(true);
            return attrs.Count() > 0 ? "Some attributes exists" : "There is no attributes";
        }
