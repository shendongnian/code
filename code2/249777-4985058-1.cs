    public class PropertyAccessor
    {
        Dictionary<string, Func<object, string>> _accessors = new Dictionary<string,Func<object,string>>();
        Type _type;
        public PropertyAccessor(Type t)
        {
            _type = t;
        }
        public string GetProperty(object obj, string propertyName)
        {
            Func<object, string> accessor;
            if (!_accessors.ContainsKey(propertyName))
            {
                ParameterExpression objExpr = Expression.Parameter(typeof(object), "obj");
                Expression e = Expression.Convert(objExpr, _type);
                e = Expression.Property(e, propertyName);
                Expression<Func<object, string>> expr = Expression.Lambda<Func<object, string>>(e, objExpr);
                accessor = expr.Compile();
                _accessors[propertyName] = accessor;
            }
            else
            {
                accessor = _accessors[propertyName];
            }
            return accessor(obj);
        }
    }
