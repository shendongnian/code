    public MessageDescriptor GetDescriptorOfMessageObject(object message) {
    	if(message == null) throw new ArgumentNullException(nameof(message));
    	var typ = message.GetType();
    		
    	var descField = typ.GetProperty("Descriptor", BindingFlags.Public|BindingFlags.Static);
    	if(descField == null)
    		throw new Exception($"Cannot locate descriptor on message of type {typ.FullName}");
    	if(descField.PropertyType != typeof(MessageDescriptor))
    		throw new Exception($"Field 'Descriptor' on type {typ.FullName} is not a MessageDescriptor");
    		
    	var desc = descField.GetValue(null) as MessageDescriptor;	
    	return desc;
    }
