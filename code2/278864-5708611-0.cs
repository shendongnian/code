    ThrowIfNullOrEmpty(strValue, "strValue");
    
    ...
    private void ThrowIfNullOrEmpty(string parameterValue, string parameterName)
    {
        if String.IsNullorEmpty(parameterValue)
        {
            throw new ArgumentException("Mandatory 'strValue' parameter empty", 
                                        parameterName);
        }
    }
