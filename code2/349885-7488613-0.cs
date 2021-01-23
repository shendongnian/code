    var method = modelBuilder.GetType().GetMethod("Entity");
    var genericMethod = method.MakeGenericMethod(type);
    var entTypConfig = genericMethod.Invoke(modelBuilder, null);
    entTypConfig.GetType()
        .InvokeMember("ToTable", BindingFlags.Public, null, entTypConfig, 
                      new object[] {type.Name});
