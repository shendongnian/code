    public delegate object DynamicInvokeWithReturnDelegate(params object[] args);
    
    public static DynamicInvokeWithReturnDelegate CreateDynamicInvokeWithReturnDelegate(MethodInfo method, object instance) {
        return args => method.Invoke(instance, args);
    }
