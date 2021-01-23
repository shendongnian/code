    static readonly Func<DataContext, Type, int, object> identityLookup = BuildIdentityLookup();
    static Func<DataContext, Type, int, object> BuildIdentityLookup()
    {
        var quickFind = new DynamicMethod("QuickFind", typeof(object), new Type[] { typeof(DataContext), typeof(Type), typeof(int) }, typeof(DataContext), true);
        var il = quickFind.GetILGenerator();
        const BindingFlags AllInstance = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        il.Emit(OpCodes.Ldarg_0); // DB
        var services = typeof(DataContext).GetField("services", AllInstance);
        il.Emit(OpCodes.Ldfld, services); // services
        var identifier = services.FieldType.GetProperty("IdentityManager", AllInstance);
        il.EmitCall(OpCodes.Callvirt, identifier.GetGetMethod(true), null); // identifier
        il.Emit(OpCodes.Ldarg_0); // identifier DB
        var mapping = typeof(DataContext).GetProperty("Mapping");
        il.EmitCall(OpCodes.Callvirt, mapping.GetGetMethod(), null); // identifier mapping
        il.Emit(OpCodes.Ldarg_1); // identifier mapping type
        il.EmitCall(OpCodes.Callvirt, mapping.PropertyType.GetMethod("GetMetaType"), null); // identifier metatype
        il.Emit(OpCodes.Ldc_I4_1); // identifier metatype 1
        il.Emit(OpCodes.Newarr, typeof(object)); // identifier metatype object[]
        il.Emit(OpCodes.Dup); // identifier metatype object[] object[]
        il.Emit(OpCodes.Ldc_I4_0); // identifier metatype object[] object[] 0
        il.Emit(OpCodes.Ldarg_2); // identifier metatype object[] object[] 0 id
        il.Emit(OpCodes.Box, typeof(int)); // identifier metatype object[] object[] 0 boxed-id
        il.Emit(OpCodes.Stelem_Ref); // identifier metatype object[]
        il.EmitCall(OpCodes.Callvirt, identifier.PropertyType.GetMethod("Find", AllInstance), null); // object
        il.Emit(OpCodes.Ret);
        return (Func<DataContext, Type, int, object>)quickFind.CreateDelegate(typeof(Func<DataContext, Type, int, object>));
    }
