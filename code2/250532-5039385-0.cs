    public class CustomDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
    	public CustomDataContractSerializerOperationBehavior(OperationDescription operationDescription) : base(operationDescription) { }
    
    	public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
    	{
    		var dictionary = new XmlDictionary(2);
    		dictionary.Add(name);
    		dictionary.Add(ns);
    
    
    		return new MyCustomDataContractSerializer(
    			type,
    			new XmlDictionaryString(dictionary, name, 0),
    			new XmlDictionaryString(dictionary, ns, 1), 
    			knownTypes);
    	}
    
    	public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
    	{
    		return new MyCustomDataContractSerializer(
    			type,
    			name,
    			ns,
    			knownTypes);
    	}
    }
    
    
    public class CustomDataContractFormatAttribute : Attribute, IOperationBehavior
    {
    	public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
    	{
    	}
    
    	public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
    	{
    		ReplaceDataContractSerializerOperationBehavior(description);
    	}
    
    	public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
    	{
    		ReplaceDataContractSerializerOperationBehavior(description);
    	}
    
    	public void Validate(OperationDescription description)
    	{
    	}
    
    	private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
    	{
    		DataContractSerializerOperationBehavior dcs = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
    
    		if (dcs != null)
    			description.Behaviors.Remove(dcs);
    
    		description.Behaviors.Add(new CustomDataContractSerializerOperationBehavior(description));
    	}
    }
