    public class AuthorizeMultiplePolicyAttribute : TypeFilterAttribute
    {
        public AuthorizeMultiplePolicyAttribute(string[] policies) : base(typeof(AuthorizeMultiplePolicyFilter))
        {
            Arguments = new object[] { policies };
        }
    }
