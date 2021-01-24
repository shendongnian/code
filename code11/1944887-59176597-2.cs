    public class MyClass
    {
        private static readonly MyClass Default = new MyClass();
        //OR
        //public static MyClass Default { get { return new MyClass(); } }
        
        public bool MyProperty{ get; set; } = true;
        public void Reset()
        {
            this.MyProperty = Default.MyProperty;
        }
    }
