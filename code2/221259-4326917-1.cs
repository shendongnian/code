    public struct A
    {
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private int SomeMethod()
        {
            return _Value;
        }
    }
    delegate int SomeMethodHandler(ref A instance);
    class Program
    {
        static void Main(string[] args)
        {
            var method = typeof(A).GetMethod("SomeMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            SomeMethodHandler d = (SomeMethodHandler)Delegate.CreateDelegate(typeof(SomeMethodHandler), method);
            A instance = new A();
            instance.Value = 5;
            Console.WriteLine(d(ref instance));
        }
    }
