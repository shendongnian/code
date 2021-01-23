    public static BaseBuilder Create(Type builderType, HttpContextBase httpContext, PathDataDictionary pathData)
    {
      if (!builderType.IsSubclassOf(baseBuilderType)) return null;
      
      BuilderConstructorDelegate del;
      if (builderConstructors.TryGetValue(builderType.FullName, out del))
        return del(httpContext, pathData);
      
      DynamicMethod dynamicMethod = new DynamicMethod("CreateBaseBuilderInstance", builderType, constructorMethodArgs, builderType);
      ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldarg_1);
      ilGenerator.Emit(OpCodes.Newobj, builderType.GetConstructor(constructorMethodArgs));
      ilGenerator.Emit(OpCodes.Ret);
      del = (BuilderConstructorDelegate)dynamicMethod.CreateDelegate(typeof(BuilderConstructorDelegate));
      builderConstructors.TryAdd(builderType.FullName, del);
      return del(httpContext, pathData);
    }
