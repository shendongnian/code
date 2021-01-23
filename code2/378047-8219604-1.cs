    var parameters = ctor.GetParameters();
    for (int i = 0; i < ctorArgsLength; i++)
    {
        EmitInt32(il, i); // [index]
        il.Emit(OpCodes.Stloc_0); // [nothing]
        il.Emit(OpCodes.Ldarg_0); //[args]
        EmitInt32(il, i); // [args][index]
        il.Emit(OpCodes.Ldelem_Ref); // [item-in-args-at-index]
        var paramType = parameters[i].ParameterType;
        if (paramType != typeof(object))
        {
            il.Emit(OpCodes.Unbox_Any, paramType); // same as a cast if ref-type
        }
    }
    il.Emit(OpCodes.Newobj, ctor); //[new-object]
    il.Emit(OpCodes.Stloc_1); // nothing
