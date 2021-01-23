    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    [Serializable]
    public class TestPropertyAttribute : System.Attribute
    {
        readonly string _name;
        
        public TestPropertyAttribute(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
    }
