    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var name = Context.GetRouteValue("controller");
            //...
        }
