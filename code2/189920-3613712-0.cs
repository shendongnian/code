    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class MyNewAttribute : Attribute
    {
        public MyNewAttribute() { }
        public MyNewAttribute(string dummy) { }
    }
