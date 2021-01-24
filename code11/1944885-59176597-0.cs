    public class MyClass
    {
        private static readonly MyClass Default;
        public bool MyProperty{ get; set; } = true;
        public void Reset()
        {
            this.MyProperty = Default.MyProperty;
        }
    }
