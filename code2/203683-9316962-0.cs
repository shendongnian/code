    public object CreatePropertyObject(IEnumerable<System.Collections.Generic.KeyValuePair<string, object>> objData)
    {
        System.Collections.Generic.Dictionary<string, Type> list = new Dictionary<string, Type>();
        foreach (var o in objData)
        {
            list.Add(o.Key, o.Value.GetType());
        }
        Type newType = BuildPropertyObject(list);
        object newObject = NewPropertyObject(newType, objData);
        return newObject;
    }
    public static object NewPropertyObject(Type newType, IEnumerable<System.Collections.Generic.KeyValuePair<string, object>> objData)
    {
        var newObject = Activator.CreateInstance(newType);
        foreach (var item in objData)
        {
            // Set the value on the new object
            newObject.GetType().GetProperty(item.Key).SetValue(newObject, item.Value, null);
        }
        return newObject;
    }
    public static Type BuildPropertyObject(IEnumerable<System.Collections.Generic.KeyValuePair<string, Type>> obj)
    {
        string nameOfDLL = "magic.dll";
        string nameOfAssembly = "magic_Assembly";
        string nameOfModule = "magic_Module";
        string nameOfType = "magic_Type";
        AssemblyName assemblyName = new AssemblyName {Name = nameOfAssembly};
        AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName,AssemblyBuilderAccess.RunAndSave);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(nameOfModule, nameOfDLL);
        TypeBuilder typeBuilder = moduleBuilder.DefineType(nameOfType, TypeAttributes.Public | TypeAttributes.Class);
        foreach (var prop in obj)
        {
            string Name = prop.Key;
            Type DataType = prop.Value;
            FieldBuilder field = typeBuilder.DefineField("_" + Name, DataType, FieldAttributes.Private);
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(Name, PropertyAttributes.SpecialName,DataType, null);
            MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName;
            MethodBuilder methodBuilderGetter = typeBuilder.DefineMethod("get_" + Name, methodAttributes, DataType, new Type[] { });
            MethodBuilder methodBuilderSetter = typeBuilder.DefineMethod("set_" + Name, methodAttributes, typeof(void), new Type[] { DataType });
            ILGenerator ilGeneratorGetter = methodBuilderGetter.GetILGenerator();
            ilGeneratorGetter.Emit(OpCodes.Ldarg_0);
            ilGeneratorGetter.Emit(OpCodes.Ldfld, field);
            ilGeneratorGetter.Emit(OpCodes.Ret);
            ILGenerator ilGeneratorSetter = methodBuilderSetter.GetILGenerator();
            ilGeneratorSetter.Emit(OpCodes.Ldarg_0);
            ilGeneratorSetter.Emit(OpCodes.Ldarg_1);
            ilGeneratorSetter.Emit(OpCodes.Stfld, field);
            ilGeneratorSetter.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(methodBuilderGetter);
            propertyBuilder.SetSetMethod(methodBuilderSetter);
        }
        // Yes! you must do this, it should not be needed but it is!
        Type dynamicType = typeBuilder.CreateType();
       
        // Save to file
        assemblyBuilder.Save(nameOfDLL);
        return dynamicType;
    }
