    var method = new DynamicMethod(commandType.Name + "_BindByName", null, new Type[] { typeof(IDbCommand), typeof(bool) });
    var il = method.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Castclass, commandType);
    il.Emit(OpCodes.Ldarg_1);
    il.EmitCall(OpCodes.Callvirt, setter, null);
    il.Emit(OpCodes.Ret);
    action = (Action<IDbCommand, bool>)method.CreateDelegate(typeof(Action<IDbCommand, bool>));
