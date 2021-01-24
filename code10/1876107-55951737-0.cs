        ...    
        string variable = ClaimsPrincipal.Current.FindFirst("SomeValue").Value;
        
        public HttpResponseMessage Get()
        {
        ...
    
