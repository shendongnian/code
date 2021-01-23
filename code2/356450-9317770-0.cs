    public static Type BuildWrapper(object targetObject)
    {
        Type targetWrapType = targetObject.GetType();
        string nameOfDLL = "magicWrapper.dll";
        string nameOfAssembly = "magic_Assembly";
        string nameOfModule = "magic_Module";
        string nameOfType = "magic_Type";
        System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName {Name = nameOfAssembly};
        System.Reflection.Emit.AssemblyBuilder assemblyBuilder =
            System.Threading.Thread.GetDomain().DefineDynamicAssembly(assemblyName,
                                                                      System.Reflection.Emit.AssemblyBuilderAccess.
                                                                          RunAndSave);
        System.Reflection.Emit.ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(nameOfModule, nameOfDLL);
        System.Reflection.Emit.TypeBuilder typeBuilder = moduleBuilder.DefineType(nameOfType,
                                                                                  System.Reflection.TypeAttributes.
                                                                                      Public |
                                                                                  System.Reflection.TypeAttributes.Class);
        System.Reflection.Emit.FieldBuilder targetWrapedObjectField =
            typeBuilder.DefineField("_" + targetWrapType.FullName.Replace(".", ""), targetWrapType,
                                    System.Reflection.FieldAttributes.Private);
        System.Reflection.MethodAttributes constructorAttributes = System.Reflection.MethodAttributes.Public;
        Type objType = Type.GetType("System.Object");
        System.Reflection.ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);
        System.Reflection.Emit.ConstructorBuilder constructorBuilder =
            typeBuilder.DefineConstructor(constructorAttributes, System.Reflection.CallingConventions.Standard,
                                          new Type[] {targetWrapType});
        System.Reflection.Emit.ILGenerator ilConstructor = constructorBuilder.GetILGenerator();
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Call, objCtor);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Nop);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Stfld, targetWrapedObjectField);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Nop);
        ilConstructor.Emit(System.Reflection.Emit.OpCodes.Ret);
        System.Reflection.MethodAttributes propertyAttributes = System.Reflection.MethodAttributes.Public |
                                                                System.Reflection.MethodAttributes.HideBySig |
                                                                System.Reflection.MethodAttributes.SpecialName;
        foreach (var prop in targetObject.GetType().GetFields())
        {
            string Name = prop.Name;
            Type DataType = prop.FieldType;
            System.Reflection.Emit.PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(Name,
                                                                                                System.Reflection.
                                                                                                    PropertyAttributes.
                                                                                                    SpecialName,
                                                                                                DataType, null);
            System.Reflection.Emit.MethodBuilder methodBuilderGetter = typeBuilder.DefineMethod("get_" + Name,
                                                                                                propertyAttributes,
                                                                                                DataType, new Type[] {});
            System.Reflection.Emit.MethodBuilder methodBuilderSetter = typeBuilder.DefineMethod("set_" + Name,
                                                                                                propertyAttributes,
                                                                                                typeof (void),
                                                                                                new Type[] {DataType});
            System.Reflection.Emit.ILGenerator ilGeneratorGetter = methodBuilderGetter.GetILGenerator();
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, targetWrapedObjectField);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, prop);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ret);
            System.Reflection.Emit.ILGenerator ilGeneratorSetter = methodBuilderSetter.GetILGenerator();
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, targetWrapedObjectField);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Stfld, prop);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ret);
            propertyBuilder.SetGetMethod(methodBuilderGetter);
            propertyBuilder.SetSetMethod(methodBuilderSetter);
        }
      
        
        System.Collections.Generic.List<System.Reflection.PropertyInfo> PropertieList = new List<PropertyInfo>();
        PropertieList.AddRange(targetObject.GetType().GetProperties(BindingFlags.Public));
        PropertieList.AddRange(targetObject.GetType().GetProperties(BindingFlags.NonPublic));
        foreach (var prop in PropertieList)
        {
            string Name = prop.Name;
            Type DataType = prop.PropertyType;
            System.Reflection.Emit.PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(Name,
                                                                                                System.Reflection.
                                                                                                    PropertyAttributes.
                                                                                                    SpecialName,
                                                                                                DataType, null);
            System.Reflection.Emit.MethodBuilder methodBuilderGetter = typeBuilder.DefineMethod("get_" + Name,
                                                                                                propertyAttributes,
                                                                                                DataType, new Type[] {});
            System.Reflection.Emit.MethodBuilder methodBuilderSetter = typeBuilder.DefineMethod("set_" + Name,
                                                                                                propertyAttributes,
                                                                                                typeof (void),
                                                                                                new Type[] {DataType});
            System.Reflection.Emit.ILGenerator ilGeneratorGetter = methodBuilderGetter.GetILGenerator();
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, targetWrapedObjectField);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Callvirt, prop.GetGetMethod());
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Stloc_0);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldloc_0);
            ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ret);
            System.Reflection.Emit.ILGenerator ilGeneratorSetter = methodBuilderSetter.GetILGenerator();
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, targetWrapedObjectField);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Callvirt, prop.GetSetMethod());
            ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ret);
            propertyBuilder.SetGetMethod(methodBuilderGetter);
            propertyBuilder.SetSetMethod(methodBuilderSetter);
        }
        // Yes! you must do this, it should not be needed but it is!
        Type dynamicType = typeBuilder.CreateType();
        // Save to file
        assemblyBuilder.Save(nameOfDLL);
        return dynamicType;
    }
