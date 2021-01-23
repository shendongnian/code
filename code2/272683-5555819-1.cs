    public void TestMethod<TargetType>(object o)
    {
        if (o is TargetType) {
            TargetType strongType = o as TargetType;
            strongType.myMethod();
        }
    }
