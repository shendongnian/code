    public class HasPermissionAttribute : AuthorizeAttribute   
    {
        public const string Policy_Prefix = "HasClaim";
        public const string Policy_Glue = ".";
        public HasPermissionAttribute(string type, string value = null)
        {
            Policy = GetPolicyValue(type, value);
        }
        private string GetPolicyValue(string type, string value)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException($"{type} cannot be null.");
            }
            List<string> parts = new List<string> { type.Replace(Policy_Glue, "_").Trim() };
            if (!string.IsNullOrWhiteSpace(value))
            {
                parts.Add(value.Replace(Policy_Glue, "_"));
            }
            string policy = $"{Policy_Prefix}{Policy_Glue}{string.Join(Policy_Glue, parts)}";
            return policy;
        }
    }
