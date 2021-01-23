    var d = new DynamicMethod("my_dynamic_get_" + field.Name, typeof(object), new[] { typeof(object) }, type, true);
    var il = d.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldfld, field);
    if (field.FieldType.IsValueType)
        il.Emit(OpCodes.Box, field.FieldType);
    else
        il.Emit(OpCodes.Castclass, typeof(object));
    il.Emit(OpCodes.Ret);
    var @delegate = (Func<object, object>)d.CreateDelegate(typeof(Func<object, object>));
        
