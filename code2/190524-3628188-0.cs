    private static void RegisterEvent(object targetObject, string eventName, string methodName)
    {
        var eventInfo = targetObject.GetType().GetEvent(eventName);
        var method = eventInfo.EventHandlerType.GetMethod("Invoke");
        var types = method.GetParameters().Select(param => param.ParameterType);
                
        var methodInfo = typeof(QueryWindow).GetMethod(methodName, new[] { typeof(object) });
        // replaced typeof(void) by null      
        var dynamicMethod = new DynamicMethod(eventInfo.EventHandlerType.Name, null, types.ToArray(), typeof(QueryWindow));
                
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator(256);
        ilGenerator.Emit(OpCodes.Ldarg_0); // I assume you want to pass "sender", but using
                                           // Ldarg_1 you would pass the "e" to "methodName"
        ilGenerator.EmitCall(OpCodes.Call, methodInfo, null);
        ilGenerator.Emit(OpCodes.Ret); // added return
    
        // removed the target argument
        var methodDelegate = dynamicMethod.CreateDelegate(eventInfo.EventHandlerType);
        eventInfo.AddEventHandler(targetObject, methodDelegate);
    }
