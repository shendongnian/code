    public class MyClass
    {
        private Expression<Func<object, object>> _expression;
        public void SetExpression(Expression<Func<object, object>> expression)
        {
            _expression = expression;
        }
    }
