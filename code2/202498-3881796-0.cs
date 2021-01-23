    using System.Reflection;
    ...
    public void DoSomething(object foo) {
        var dataType = foo.GetType();
        
        type.GetProperty("SomeDynamicName").SetValue(foo, someOtherValue);
    }
