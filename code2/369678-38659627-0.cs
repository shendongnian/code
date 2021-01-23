    public class MyBaseClass
    {
        internal void InitializeCore()
        {
            OnInitialize();
        }
        protected virtual void OnInitialize()
        {
            Console.WriteLine("MyBaseClass initializer");
        }
        public MyBaseClass()
        {
            Console.WriteLine("MyBaseClass constructor");
            this.Initialize();
        }
    }
    public class MyDerivedClass : MyBaseClass
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Console.WriteLine("MyDerivedClass initializer");
        }
        public MyDerivedClass() : base()
        {
            Console.WriteLine("MyDerivedClass constructor");
            this.Initialize();
        }
    }
    public static class MyClassExtensions
    {
        public static void Initialize<TClass>(this TClass obj) where TClass : MyBaseClass
        {
            if (obj.GetType() == typeof(TClass))
                obj.InitializeCore();
        }
    }
