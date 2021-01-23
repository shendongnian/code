    void Main()
    {
        var setter = GetPropertySetter<MyClass>("MyProperty");
        
        var myClass = new MyClass();
        setter(myClass, "This was set by the setter");
        Console.WriteLine(myClass.MyProperty);
    }
    
    Action<T, object> GetPropertySetter<T>(string propertyName) 
    {
        var property = typeof(T).GetProperty(propertyName);
        var target = Expression.Parameter(typeof(T));
        var value = Expression.Parameter(typeof(object));
        var assignment = Expression.Assign(Expression.MakeMemberAccess(target, property), Expression.Convert(value, property.PropertyType));
    	var propertyGetterExpression = Expression.Lambda<Action<T, object>>(assignment, target, value);
        return propertyGetterExpression.Compile();
    }
    
    class MyClass {
        public string MyProperty { get; set; }
    }
