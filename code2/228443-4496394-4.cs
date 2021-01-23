    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    sealed class RegisterToFactoryAttribute : Attribute
    {
        public Type TypeToRegister { get; set; }
        public RegisterToFactoryAttribute(Type typeToRegister)
        {
            TypeToRegister = typeToRegister;
            // Registration code
        }
    }
