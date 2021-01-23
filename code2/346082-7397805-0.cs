    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return ResourceManager.Current.GetResourceString(name);
        }
    }
