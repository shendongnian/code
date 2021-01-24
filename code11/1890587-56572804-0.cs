    public class AuthorizeMultiplePolicyAttribute : TypeFilterAttribute
    {
        public AuthorizeMultiplePolicyAttribute(string role, string policy) : base(typeof(AuthorizeMultiplePolicyFilter))
        {
            Arguments = new object[] { role, policy };
        }
    }
