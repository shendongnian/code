    public static ObjectActivator CreateCtor(Type type)
    {
        if (type == null)
        {
            Error.ArgumentNull("type");
        }
        ConstructorInfo emptyConstructor = type.GetConstructor(Type.EmptyTypes);
        var dynamicMethod = new DynamicMethod("CreateInstance", type, Type.EmptyTypes, true);
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Nop);
        ilGenerator.Emit(OpCodes.Newobj, emptyConstructor);
        ilGenerator.Emit(OpCodes.Ret);
        return (ObjectActivator)dynamicMethod.CreateDelegate(typeof(ObjectActivator));
    }
    
    public delegate object ObjectActivator();
