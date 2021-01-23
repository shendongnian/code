    public static class ValidatorEngine
    {
        static void Main()
        {
            string model = "abc";
            ValidatorEngine.Validate(() => UpdateByModel(model));
        }
        public static void Validate(Expression<Action> action)
        {
            var methodCall = action.Body as MethodCallExpression;
            if (methodCall == null) throw new InvalidOperationException("Expected a method-call");
            Console.WriteLine("Method: " + methodCall.Method.DeclaringType.Name + "." + methodCall.Method.Name);
            foreach (Expression arg in methodCall.Arguments)
            {
                Console.WriteLine("Arg: " + Evaluate(arg));
            }
        }
        static object Evaluate(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)exp).Value;
                case ExpressionType.MemberAccess:
                    var me = (MemberExpression)exp;
                    switch (me.Member.MemberType)
                    {
                        case System.Reflection.MemberTypes.Field:
                            return ((FieldInfo)me.Member).GetValue(Evaluate(me.Expression));
                        case MemberTypes.Property:
                            return ((PropertyInfo)me.Member).GetValue(Evaluate(me.Expression), null);
                        default:
                            throw new NotSupportedException(me.Member.MemberType.ToString());
                    }
                default:
                    throw new NotSupportedException(exp.NodeType.ToString());
            }
        }
        static void UpdateByModel(object model) {
            throw new NotImplementedException();
        }
    }
