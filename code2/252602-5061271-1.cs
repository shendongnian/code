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
                Console.WriteLine("Appears like 'this' is null.");
        }
    
        static void Main()
        {
            new Foo().InstanceMethod();
        }
    }
