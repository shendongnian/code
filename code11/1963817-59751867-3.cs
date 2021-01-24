    public class MyClass
    {
        private Expression<Func<object, object>> _expression;
        public void SetExpression(Expression<Func<object, object>> expression)
        {
            _expression = expression;
        }
        public void SomeOperation<T>(T input) {
           if(_expression is Expression<Func<T, object>> expression) {
               // use `expression` in the correct type T
           } else {
               // do something if expression is not of type T. 
               // i.e.log error or throw exception
           }
        }
    }
