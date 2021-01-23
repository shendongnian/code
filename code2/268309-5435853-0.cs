    protected internal override WebServiceResultParser<RegistrionResult> 
        GetParser<RegistrationResult>()
    {
        return new RegistrationResultParser(this);
    }
