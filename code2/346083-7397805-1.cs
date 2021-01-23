    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute(string resourceTag)
        {
            ErrorMessage = GetMessageFromResource(resourceTag);
        }
        private static String GetMessageFromResource(String resourceTag)
        {
            return ResourceManager.Current.GetResourceString(resourceTag);
        }
    }
