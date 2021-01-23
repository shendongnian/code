    private static DbCompiledModel GetModel()
    {
        var builder = new DbModelBuilder();
        ... // your context configuration
        var model = builder.Build(...); 
        EdmModel store = model.GetStoreModel();
        store.AddItem(GetRowVersionFunctionDef(model));
        DbCompiledModel compiled = model.Compile();
        return compiled;
    }
    
    private static EdmFunction GetRowVersionFunctionDef(DbModel model)
    {
        EdmFunctionPayload payload = new EdmFunctionPayload();
        payload.IsComposable = true;
        payload.Schema = "common";
        payload.StoreFunctionName = "IsNewerThan";
        payload.ReturnParameters = new FunctionParameter[]
        {
            FunctionParameter.Create("ReturnValue", 
                GetStorePrimitiveType(model, PrimitiveTypeKind.Boolean), ParameterMode.ReturnValue)
        };
        payload.Parameters = new FunctionParameter[]
        {
            FunctionParameter.Create("CurrVersion",  GetRowVersionType(model), ParameterMode.In),
            FunctionParameter.Create("BaseVersion",  GetRowVersionType(model), ParameterMode.In)
        };
        EdmFunction function = EdmFunction.Create("IsRowVersionNewer", "EFModel",
            DataSpace.SSpace, payload, null);
        return function;
    }
    private static EdmType GetStorePrimitiveType(DbModel model, PrimitiveTypeKind typeKind)
    {
        return model.ProviderManifest.GetStoreType(TypeUsage.CreateDefaultTypeUsage(
            PrimitiveType.GetEdmPrimitiveType(typeKind))).EdmType;
    }
    private static EdmType GetRowVersionType(DbModel model)
    {
        // get 8-byte array type
        var byteType = PrimitiveType.GetEdmPrimitiveType(PrimitiveTypeKind.Binary);
        var usage = TypeUsage.CreateBinaryTypeUsage(byteType, true, 8);
    
        // get the db store type
        return model.ProviderManifest.GetStoreType(usage).EdmType;
    }
