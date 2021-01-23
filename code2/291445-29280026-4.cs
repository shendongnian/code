    using System.Reflection;
    
    public SomeMethod(ClassA a, ClassB b, ClassC c)
    {
        CheckNullParams(MethodBase.GetCurrentMethod(), a, b, c);
        // do something here
    }
