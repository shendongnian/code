    [Foo]
    class Program
    {
       
        static void Main(string[] args) {}
    
             
    }
    [System.Serializable]
    sealed class FooAttribute : CodeAccessSecurityAttribute
    {
        public FooAttribute(SecurityAction action = SecurityAction.Demand) : base(action) { }
        public override System.Security.IPermission CreatePermission() { return null; }
    }
