    MethodInfo methodToReplace = ...
    RuntimeHelpers.PrepareMetod(methodToReplace.MethodHandle);
    
    var getDynamicHandle = Delegate.CreateDelegate(Metadata<Func<DynamicMethod, RuntimeMethodHandle>>.Type, Metadata<DynamicMethod>.Type.GetMethod("GetMethodDescriptor", BindingFlags.Instance | BindingFlags.NonPublic)) as Func<DynamicMethod, RuntimeMethodHandle>;
    
    var newMethod = new DynamicMethod(...);
    var body = newMethod.GetILGenerator();
    body.Emit(...) // do what you want.
    body.Emit(OpCodes.jmp, methodToReplace);
    body.Emit(OpCodes.ret);
    
    var handle = getDynamicHandle(newMethod);
    RuntimeHelpers.PrepareMethod(handle);
    
    *((int*)new IntPtr(((int*)methodToReplace.MethodHandle.Value.ToPointer() + 2)).ToPointer()) = handle.GetFunctionPointer().ToInt32();
    
    //all call on methodToReplace redirect to newMethod and methodToReplace is called in newMethod and you can continue to debug it, enjoy.
