    [OperationContract]
    public bool IsLoggedIn()
    {
        return ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated;
    }
