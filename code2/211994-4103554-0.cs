    Func<object, bool> isMyGenericClassInstance = obj =>
        {
            if (obj == null)
                return false; // otherwise will get NullReferenceException
            Type t = obj.GetType().BaseType;
            if (t != null)
            {
                if (t.IsGenericType)
                    return t.GetGenericTypeDefinition() == typeof(MyGenericClass<>);
            }
            return false;
        };
    bool willBeTrue = isMyGenericClassInstance(new Foo());
    bool willBeFalse = isMyGenericClassInstance("foo");
