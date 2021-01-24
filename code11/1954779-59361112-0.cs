    public abstract class MyClass<TDerived, TValue> where TDerived : MyClass<TDerived, TValue>
    {
        protected MyClass(int status, TValue value)
        {
            this.Status = status;
            this.Value = value;
        }
        public int Status { get; set; }
        public TValue Value { get; set; }
        public static implicit operator TDerived(MyClass<TDerived, TValue> myClass)
            => myClass as TDerived;
    }
    public class SpecificClass : MyClass<SpecificClass, string>
    {
        public SpecificClass(int status, string value) : base(status, value)
        {
            // The ONLY way to instantiate a MyClass<> is from a derived class
            // such as this.
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<SpecificClass, string> my_class = new SpecificClass(-1, "ABC");
            SpecificClass my_specific = my_class;
        }
    }
