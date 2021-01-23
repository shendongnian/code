    [SecurityCritical]
    private ConstructorBuilder DefineConstructorNoLock(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
    {
    	this.CheckContext(parameterTypes);
    	this.CheckContext(requiredCustomModifiers);
    	this.CheckContext(optionalCustomModifiers);
    	this.ThrowIfCreated();
    	string name;
    	if ((attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
    	{
    		name = ConstructorInfo.ConstructorName;
    	}
    	else
    	{
    		name = ConstructorInfo.TypeConstructorName;
    	}
    	attributes |= MethodAttributes.SpecialName;
    	ConstructorBuilder result = new ConstructorBuilder(name, attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers, this.m_module, this);
    	this.m_constructorCount++;
    	return result;
    }
