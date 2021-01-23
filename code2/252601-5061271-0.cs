    class Foo
    {
        public static implicit operator string(Foo foo)
        {
            return null;
        }
    
        void InstanceMethod()
        {
            string @this = this;
    
            if (@this == null)
                Console.WriteLine("This is null.");
        }
    
        static void Main()
        {
            new Foo().InstanceMethod();
        }
    }
