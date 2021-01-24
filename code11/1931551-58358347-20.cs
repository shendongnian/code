    public abstract class SchemaCustomizationGenerationProvider : JSchemaGenerationProvider
    {
        [ThreadStatic]
        static HashSet<Tuple<Type, Type>> _types;
        HashSet<Tuple<Type, Type>> TypesBeingGenerated { get { return _types ?? (_types = new HashSet<Tuple<Type, Type>>()); } }
        void PushType(Type type)
        {
            if (!TypesBeingGenerated.Add(Tuple.Create(GetType(), type)))
            {
                throw new JSchemaException(string.Format("Unexpected recursion for type {0}", type));
            }
        }
        void PopType(Type type) { TypesBeingGenerated.Remove(Tuple.Create(GetType(), type)); }
        bool CurrentlyGeneratingForType(Type type) { return TypesBeingGenerated.Contains(Tuple.Create(GetType(), type)); }
        static JsonContract GetContract(JSchemaTypeGenerationContext context) { return context.Generator.ContractResolver.ResolveContract(context.ObjectType); }
        static Type GetType(JsonContract contract) { return Nullable.GetUnderlyingType(contract.UnderlyingType) ?? contract.UnderlyingType; }
        public sealed override bool CanGenerateSchema(JSchemaTypeGenerationContext context)
        {
            var contract = GetContract(context);
            var type = GetType(contract);
            if (CurrentlyGeneratingForType(type))
                return false;
            if (!CanCustomize(context, contract, type))
                return false;
            return true;
        }
        public override JSchema GetSchema(JSchemaTypeGenerationContext context)
        {
            var contract = GetContract(context);
            var type = GetType(contract);
            PushType(type);
            try
            {
                return Customize(context, contract, type, context.Generator.Generate(context.ObjectType));
            }
            finally
            {
                PopType(type);
            }
        }
        protected virtual bool CanCustomize(JSchemaTypeGenerationContext context, JsonContract contract, Type type)
        {
            return true;
        }
        protected abstract JSchema Customize(JSchemaTypeGenerationContext context, JsonContract contract, Type type, JSchema schema);
    }
