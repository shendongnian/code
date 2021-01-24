    using Assembly = UnityEditor.Compilation.Assembly;
    private static void BuildMyProtoModel()
    {
        RuntimeTypeModel typeModel = TypeModel.Create();
        foreach (var t in GetTypes(CompilationPipeline.GetAssemblies(AssembliesType.Player)))
        {
            var contract = t.GetCustomAttributes(typeof(ProtoContractAttribute), false);
            if (contract.Length > 0)
            {
                MetaType metaType = typeModel.Add(t, true);
                // support ISerializationCallbackReceiver
                if (typeof(ISerializationCallbackReceiver).IsAssignableFrom(t))
                {
                    MethodInfo beforeSerializeMethod = t.GetMethod("OnBeforeSerialize");
                    MethodInfo afterDeserializeMethod = t.GetMethod("OnAfterDeserialize");
                    metaType.SetCallbacks(beforeSerializeMethod, null, null, afterDeserializeMethod);
                }
                //add unity types
                typeModel.Add(typeof(Vector2), false).Add("x", "y");
                typeModel.Add(typeof(Vector3), false).Add("x", "y", "z");
            }
        }
        typeModel.Compile("MyProtoModel", "MyProtoModel.dll"); //build model
        string protoShema = typeModel.GetSchema(null);//content for .proto file, you can generate a proto file for a specific type by passing it instead of null
    }
    private static IEnumerable<Type> GetTypes(IEnumerable<Assembly> assemblies)
    {
        foreach (Assembly assembly in assemblies)
        {
            foreach (Type type in AppDomain.CurrentDomain.Load(assembly.name).GetTypes())
            {
                yield return type;
            }
        }
    }
