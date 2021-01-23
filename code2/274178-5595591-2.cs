    public class WhereSpecifier
    {
        public WhereSpecifier(string column, CheckMethod method, string value, CheckMethodModifiers modifiers)
        {
            Modifiers = modifiers;
            Value = value;
            Column = column;
            Method = method;
        }
        public WhereSpecifier(string column, CheckMethod method, string value)
            : this(column, method, value, CheckMethodModifiers.None)
        {
        }
        public Expression Selector { get; set; }
        public ParameterExpression Parameter { get; set; }
        public string Column { get; set; }
        public CheckMethod Method { get; set; }
        public CheckMethodModifiers Modifiers { get; set; }
        public string Value { get; set; }
    }
