    public void TestMethod<TargetType>(object o)
    {
        if (typeof(TargetType).IsAssignableFrom(o.GetType())) {
            TargetType strongType = o as TargetType;
            strongType.myMethod();
        }
    }
