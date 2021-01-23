    private void AddEvent(EventInfo interfaceEvent)
    {
        MethodAttributes eventMethodAttr = MethodAttributes.Public | MethodAttributes.HideBySig |             MethodAttributes.Virtual | MethodAttributes.NewSlot | MethodAttributes.Final | MethodAttributes.SpecialName;
        MethodImplAttributes eventMethodImpAtr = MethodImplAttributes.Managed | MethodImplAttributes.Synchronized;
        
        string qualifiedEventName = string.Format("{0}.{1}", typeToIntercept.Name, interfaceEvent.Name);
        string addMethodName = string.Format("add_{0}", interfaceEvent.Name);
        string remMethodName = string.Format("remove_{0}", interfaceEvent.Name);
        EventBuilder eBuilder = typeBuilder.DefineEvent(qualifiedEventName, EventAttributes.None, interfaceEvent.EventHandlerType);
        // ADD method
        MethodBuilder addMethodBuilder = typeBuilder.DefineMethod(addMethodName, eventMethodAttr, null, new[] { interfaceEvent.EventHandlerType }); 
        addMethodBuilder.SetImplementationFlags(eventMethodImpAtr);
        
        // Code generation      
        ILGenerator ilgen = addMethodBuilder.GetILGenerator();
        ilgen.Emit(OpCodes.Nop);
        ilgen.Emit(OpCodes.Ldarg_0);             
        ilgen.Emit(OpCodes.Ldfld, targetField);
        ilgen.Emit(OpCodes.Ldarg_1);               
        ilgen.Emit(OpCodes.Callvirt, interfaceEvent.GetAddMethod());
        ilgen.Emit(OpCodes.Nop);
        ilgen.Emit(OpCodes.Ret);
        
        // REMOVE method     
        MethodBuilder removeMethodBuilder = typeBuilder.DefineMethod(remMethodName, eventMethodAttr, null, new[] { interfaceEvent.EventHandlerType });
        removeMethodBuilder.SetImplementationFlags(eventMethodImpAtr);
      
        // Code generation     
        ilgen = removeMethodBuilder.GetILGenerator();
        ilgen.Emit(OpCodes.Nop);
        ilgen.Emit(OpCodes.Ldarg_0);
        ilgen.Emit(OpCodes.Ldfld, targetField);
        ilgen.Emit(OpCodes.Ldarg_1);
        ilgen.Emit(OpCodes.Callvirt, interfaceEvent.GetRemoveMethod());
        ilgen.Emit(OpCodes.Nop);
        ilgen.Emit(OpCodes.Ret);
        
        // Finally, setting the AddOn and RemoveOn methods for our event    
        eBuilder.SetAddOnMethod(addMethodBuilder);     
        eBuilder.SetRemoveOnMethod(removeMethodBuilder);
    }
