    private class ValueExtractor : ExpressionVisitor
    {
        private readonly Dictionary<Type, Dictionary<string, object>> anonymousFields;
        public ValueExtractor()
        {
            Arguments = new List<object>();
            anonymousFields = new Dictionary<Type, Dictionary<string, object>>();
        }
        public List<object> Arguments { get; }
        protected override Expression VisitMember(MemberExpression node)
        {
            var memberName = node.Member.Name;
            var type = node.Member.DeclaringType;
            var baseResult = base.VisitMember(node);
            if (anonymousFields.ContainsKey(type))
                Arguments.Add(anonymousFields[type][memberName]);
            return baseResult;
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            var constantType = node.Type;
            if (constantType == typeof(int) || constantType == typeof(string)) // and so on
            {
                Arguments.Add(node.Value);
            }
            else if (IsAnonymousType(constantType) && !anonymousFields.ContainsKey(constantType))
            {
                var fields = new Dictionary<string, object>();
                anonymousFields.Add(constantType, fields);
                foreach (var field in constantType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.GetField))
                    fields.Add(field.Name, field.GetValue(node.Value));
            }
            return base.VisitConstant(node);
        }
        private static bool IsAnonymousType(Type type)
        {
            var hasSpecialChars = type.Name.Contains("<") || type.Name.Contains(">");
            return hasSpecialChars && type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Any();
        }
    }
