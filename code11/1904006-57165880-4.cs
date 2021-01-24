    /// human generated
    public partial class MyClassWrapper
    {
        private readonly MyClass wrapped;
        public MyClassWrapper(MyClass wrapped)
        {
            this.wrapped = wrapped;
        }
        [Submit]
        public int Num1 { get => this.wrapped.Num1; set => this.wrapped.Num1 = value; }
        
        [Submit]
        public int Num2 { get => this.wrapped.Num2; set => this.wrapped.Num2 = value; }
        
        [Submit]
        public string Str1 { get => this.wrapped.Str1; set => this.wrapped.Str1 = value; }
        
        [Submit]
        public string Str2 { get => this.wrapped.Str2; set => this.wrapped.Str2 = value; }
    }
