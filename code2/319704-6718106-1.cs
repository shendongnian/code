    public SoapAuthenticationHeader AuthHeader;
            
    [SoapHeader("AuthHeader")]
    [WebMethod()]
    public ServiceResponse<bool> Update(int clientId)
