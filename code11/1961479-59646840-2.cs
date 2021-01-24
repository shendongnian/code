    MethodReference performTediousOperationMethodReference =
        new MethodReference(
            name: "PerformTediousOperation",
            returnType: moduleDefinition.TypeSystem.Void,
            declaringType: operatorTypeReference)
        {
            HasThis = true
        };
    var genericParameter = new GenericParameter("T", performTediousOperationMethodReference);
    performTediousOperationMethodReference.GenericParameters.Add(genericParameter);
    
    GenericInstanceMethod performTediousOperationInstanceMethod = 
    	new GenericInstanceMethod(performTediousOperationMethodReference) 
    		{
    			GenericArguments = { moduleDefinition.ImportReference(typeof(int)) }
    		};
