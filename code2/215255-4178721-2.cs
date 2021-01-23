    public delegate void DynamicInvokeDelegate(params object[] args);
    
    public static DynamicInvokeDelegate CreateDynamicInvokeDelegate(MethodInfo method, object instance) {
        return args => method.Invoke(instance, args);
    }
