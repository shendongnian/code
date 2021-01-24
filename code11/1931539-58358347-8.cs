    public abstract class PropertyCustomizationGenerationProvider : JSchemaGenerationProvider
    {
        [ThreadStatic]
        static HashSet<Tuple<Type, Type>> _types;
        HashSet<Tuple<Type, Type>> TypesBeingGenerated { get { return _types ?? (_types = new HashSet<Tuple<Type,Type>>()); } }
        void PushType(Type type)
        {
            if (!TypesBeingGenerated.Add(Tuple.Create(GetType(), type)))
            {
                throw new JSchemaException(string.Format("Unexpected recursion for type {0}", type));
            }
        }
        void PopType(Type type) { TypesBeingGenerated.Remove(Tuple.Create(GetType(), type)); }
        bool CurrentlyGeneratingForType(Type type) { return TypesBeingGenerated.Contains(Tuple.Create(GetType(), type)); }
        static bool TryGetType(JSchemaTypeGenerationContext context, out JsonObjectContract contract, out Type type)
        {
            contract = context.Generator.ContractResolver.ResolveContract(context.ObjectType) as JsonObjectContract;
            type = contract == null ? null : Nullable.GetUnderlyingType(contract.UnderlyingType) ?? contract.UnderlyingType;
            return contract != null && type != null;
        }
        public sealed override bool CanGenerateSchema(JSchemaTypeGenerationContext context)
        {
            JsonObjectContract contract;
            Type type;
            if (!TryGetType(context, out contract, out type))
                return false;
            if (CurrentlyGeneratingForType(type))
                return false;
            if (!CanCustomize(context, contract, type))
                return false;
            return true;
        }
        public override JSchema GetSchema(JSchemaTypeGenerationContext context)
        {
            JsonObjectContract contract;
            Type type;
            if (!TryGetType(context, out contract, out type))
                throw new JSchemaException(string.Format("Unexpected type {0}", context.ObjectType));
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
        protected virtual bool CanCustomize(JSchemaTypeGenerationContext context, JsonObjectContract contract, Type type)
        {
            return true;
        }
        protected abstract JSchema Customize(JSchemaTypeGenerationContext context, JsonObjectContract contract, Type type, JSchema schema);
    }
