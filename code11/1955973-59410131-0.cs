        private static void Write<T1, T2>(Expression<Func<T1, T2>> expression)
        {
            var me = ((MemberExpression)expression.Body);
           
           Console.WriteLine(me.Expression.Type.GetProperty(me.Member.Name)
            .GetCustomAttributes<XmlElementAttribute>().First().ElementName);
        }
