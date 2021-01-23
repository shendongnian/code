    public delegate void DelegateTypeWithParam(object param);
    public delegate void DelegateTypeWithoutParam();
    public void MethodWithCallbackParam(DelegateTypeWithParam callback, DelegateTypeWithoutParam callback2)
    {
        callback(new object());
        callback2();
    }
    // must conform to the delegate spec
    public void MethodWithParam(object param) { }
    public void MethodWithoutParam() { }
    public void PassCallback()
    {
       MethodWithCallbackParam(MethodWithParam, MethodWithoutParam);
    }
