    public delegate void DelegateTypeWithParam(object param);
    public delegate void DelegateTypeWithoutParam();
    public void MethodWithCallbackParam(DelegateTypeWithParam callback, DelegateTypeWithoutParam callback2)
    {
        callback(new object());
        Console.WriteLine(callback.Method.Name);
        callback2();
        Console.WriteLine(callback2.Method.Name);
    }
    // must conform to the delegate spec
    public void MethodWithParam(object param) { }
    public void MethodWithoutParam() { }
    public void PassCallback()
    {
       MethodWithCallbackParam(MethodWithParam, MethodWithoutParam);
    }
