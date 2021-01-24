    var genericParameter = new GenericParameter("T", performTediousOperationMethodReference);
    performTediousOperationMethodReference.GenericParameters.Add(genericParameter);
    
    			
    GenericInstanceMethod performTediousOperationInstanceMethod = 
    	new GenericInstanceMethod(performTediousOperationMethodReference) 
    		{
    			GenericArguments = { runTimeDeterminedType }
    		};
