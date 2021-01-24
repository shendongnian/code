    public class DocumentContractResolver : DefaultContractResolver
    {
		ThreadLocal<Stack<Document>> ActiveDocuments = new ThreadLocal<Stack<Document>>(() => new Stack<Document>());
        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            CustomizeDocumentContract(contract);
            CustomizeMyObjectContract(contract);
            return contract;
        }
        void CustomizeDocumentContract(JsonContract contract)
        {
            if (typeof(Document).IsAssignableFrom(contract.UnderlyingType))
            {
                contract.OnDeserializingCallbacks.Add((o, c) => ActiveDocuments.Value.Push((Document)o));
                contract.OnDeserializedCallbacks.Add((o, c) => ActiveDocuments.Value.Pop());
            }
        }
        void CustomizeMyObjectContract(JsonContract contract)
        {
            if (typeof(Child) == contract.UnderlyingType)
            {
                contract.DefaultCreator = () => new Child(ActiveDocuments.Value.Peek());
                contract.DefaultCreatorNonPublic = false;
            }
        }
    }
