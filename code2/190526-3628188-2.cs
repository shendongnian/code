    private static void RegisterEvent(object targetObject, string eventName, string methodName)
    {
        var eventInfo = targetObject.GetType().GetEvent(eventName);
        var method = eventInfo.EventHandlerType.GetMethod("Invoke");
        var types = method.GetParameters().Select(param => param.ParameterType);
                
        var methodInfo = typeof(QueryWindow).GetMethod(methodName, new[] { typeof(object) });
        // replaced typeof(void) by null      
        var dynamicMethod = new DynamicMethod(eventInfo.EventHandlerType.Name, null, types.ToArray(), typeof(QueryWindow));
                
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator(256);
        // Using Ldarg_0 to pass the sender to methodName ; Ldarg_1 to pass the event args
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.EmitCall(OpCodes.Call, methodInfo, null);
        
        // Added return
        ilGenerator.Emit(OpCodes.Ret); 
    
        // Removed parameter definition (implicit from DynamicMethod constructor)
        // Removed the target argument
        var methodDelegate = dynamicMethod.CreateDelegate(eventInfo.EventHandlerType);
        eventInfo.AddEventHandler(targetObject, methodDelegate);
    }
