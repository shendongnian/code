    namespace TestIdentityServer4.Validators
    {
        public class AuthCodeValidator : IExtensionGrantValidator
        {
            public string GrantType => "app2_auth_code";
            public async Task ValidateAsync(ExtensionGrantValidationContext context)
            {
                var code = context.Request.Raw.Get("code");
                var state = context.Request.Raw.Get("state");
                var sub = GetSubByCode(code, state);
                if (string.IsNullOrEmpty(sub))
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                    return;
                }
                
                context.Result = new GrantValidationResult(sub, GrantType);
                return;
            }
            //Check the code and the state (and the request are still active) and returns sub
            private string GetSubByCode(string code, string state)
            {
                return "tu1";
            }
        }
    }
