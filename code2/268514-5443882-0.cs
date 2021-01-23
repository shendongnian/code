    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayForAttribute : Attribute
    {
        public DisplayForAttribute(string role)
        {
            Role = role;
        }
        public string Role { get; private set; }
    }
