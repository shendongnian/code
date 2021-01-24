    public class ArgWrapper
    {
        public static ArgWrapper Create<T>(Expression<Func<T>> expression)
        {
            T valueAsT = expression.Compile()();
            string value = Convert.ToString(valueAsT, CultureInfo.InvariantCulture);
            // Get type name
            string type = valueAsT?.GetType().FullName ?? "null";
            string name = "";
            // Get name by traversing memberexpressions from right to left
            MemberExpression memberExpression = expression.Body as MemberExpression;
            Expression traverseExpression = expression.Body;
            while (traverseExpression != null && traverseExpression is MemberExpression)
            {
                memberExpression = traverseExpression as MemberExpression;
                name = memberExpression.Member.Name + "." + name;
                traverseExpression = memberExpression.Expression;
            }
            // If the last memberexpression has no expression, this is a global class name, we want to include
            if (traverseExpression == null && memberExpression != null)
            {
                name = memberExpression.Member.DeclaringType.Name + "." + name;
            }
            var argWrapper = new ArgWrapper();
            argWrapper.Name = name;
            argWrapper.Type = type;
            argWrapper.Value = value;
            return argWrapper;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
