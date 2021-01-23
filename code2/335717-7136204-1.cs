    [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
    [PrincipalPermission(SecurityAction.Demand, Role = "OPERATOR")]
    public void SomeServiceCall(string foo)
    {
        // In your case this would be an AJAX endpoint, not a void method
    }
