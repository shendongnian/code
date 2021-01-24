    public static class PropertyGetterEx<TObject, TPropertyType>
    {
        private static readonly Func<TObject, TPropertyType[]> _getterFunc;
    
        static PropertyGetterEx()
        {
            // The code below constructs the following delegate:
            //
            // o => object.ReferenceEquals(o, null)
            //      ? null
            //      : new TPropertyType[] { o.Prop1, o.Prop2, ... };
            //
    
            // An expression for the parameter `o`
            var objParam = Expression.Parameter(typeof(TObject), "o");
    
            // Create expressions for `o.Prop1` ... `o.PropN`
            var propertyAccessExprs = GetPropertyInfos()
                .Select(x => Expression.MakeMemberAccess(objParam, x));
    
            // Create an expression for `new TPropertyType[] { o.Prop1, o.Prop2, ... }`
            var arrayInitExpr = Expression.NewArrayInit(
                typeof(TPropertyType),
                propertyAccessExprs);
    
            // Create an expression for `object.ReferenceEquals(o, null)`
            var refEqualsInfo = typeof(object).GetMethod(nameof(object.ReferenceEquals));
            var refEqualsExpr = Expression.Call(
                refEqualsInfo,
                objParam,
                Expression.Constant(null, typeof(TPropertyType)));
    
            // The condition expression
            var conditionExpr = Expression.Condition(
                refEqualsExpr,
                Expression.Constant(null, typeof(TPropertyType[])),
                arrayInitExpr);
    
            _getterFunc = Expression
                .Lambda<Func<TObject, TPropertyType[]>>(
                    conditionExpr,
                    objParam)
                .Compile();
        }
    
        private static PropertyInfo[] GetPropertyInfos()
        {
            var properties = typeof(TObject).GetProperties()
                // "IsAssignableFrom" is used to support derived types too
                .Where(x => typeof(TPropertyType).IsAssignableFrom(x.PropertyType))
                // Check that the property is accessible
                .Where(x => x.GetMethod != null && x.GetMethod.IsPublic && !x.GetMethod.IsStatic)
                .ToArray();
    
            return properties;
        }
    
        public static TPropertyType[] GetValues(TObject obj)
        {
            return _getterFunc(obj);
        }
    }
