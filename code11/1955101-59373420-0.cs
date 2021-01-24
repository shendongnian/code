    public class DynamicKeyJwtValidationHandler : JwtSecurityTokenHandler, ISecurityTokenValidator
        {
            public SecurityKey GetKeyForClaimedId(string claimedId)
            {
                throw new NotImplementedException();
            }
            public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
            {
                //
                // if your class is in the different assembly then 
                // Assembly.GetEntryAssembly().GetType("yourNamespace.YourClass");
                Type type = Assembly.GetEntryAssembly().GetType("YourClass");
                object entity = Activator.CreateInstance(type);
                var instanceOfClass = (YourClass)entity;
                instanceOfClass.Go();
    
                //
    
    
                ClaimsPrincipal cp = new ClaimsPrincipal();
                validatedToken = null;
                try
                {
                    cp = base.ValidateToken(token, validationParameters, out validatedToken);
                }
                catch (Exception) { }
    
                return cp;
            }
        }
    
        public class YourClass
        {
            public void Go()
            {
    
            }
        }
