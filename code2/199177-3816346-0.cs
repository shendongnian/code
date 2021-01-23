    var properties = MyClass.GetType().GetProperties();
    var values = new [] {"test1", "test55", ... };
    
    for(var i=0; i<properties.Count; i++)
       DoSomethingAndAssign(properties[i], values[i], MyClass);
    
    public void DoSomethingAndAssign(PropertyInfo prop, string theValue, Object theClass)
    {
       var setValue = /*do anything you want based on theValue before setting*/
    
       //will throw an exception if theClass is null, theClass doesn't have the property,
       //or the property cannot be set to a value of setValue's type.
       prop.SetValue(theClass, setValue, null);
    }
