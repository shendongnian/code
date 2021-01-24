    get
    {  
    
                        _itemClient?.DefaultRequestHeaders.Add("Username", GetSystemParmValue<string>(SystemParameterKey.USERNAME));
                        _itemClient?.DefaultRequestHeaders.Add("Password", GetSystemParmValue<string>(SystemParameterKey.PASSWORD, true));
        
                        return _itemClient;
    }
