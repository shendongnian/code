    object validator;  // An object known to implement IValidation<T>.
    object toValidate; // The object which can be validated by using the validator.
    // Assume validator is IValidation<string> and toValidate a string.
    
    IValidation<object> validation
        = Proxy.CreateGenericInterfaceWrapper<IValidation<object>>( validator );
    
    validation.IsValid( toValidate ); // This works! No need to know about the type.
    
    // The following will throw an InvalidCastException.
    //validation.IsValid( 10 );
