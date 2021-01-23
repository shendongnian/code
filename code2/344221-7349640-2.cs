    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    class AllowedMethodAttribute : Attribute
    {
        public AllowedMethodAttribute(bool methodAllowed)
        {
            this.AllowedToExecute = methodAllowed;
        }
        public bool AllowedToExecute { get; private set; }
    }
