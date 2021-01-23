    public class Parent : IInitialize
    {
        public virtual void OnInitialize()
        {
            Console.WriteLine("Parent");
        }
        public Parent()
        {
            this.Initialize();
        }
    }
    public class Child : Parent
    {
        public Child()
        {
            this.Initialize();
        }
        public override void OnInitialize()
        {
            Console.WriteLine("Child");
        }
    }
    public class GrandChild : Child
    {
        public GrandChild()
        {
            this.Initialize();
        }
        public override void OnInitialize()
        {
            Console.WriteLine("GrandChild");
        }
    }
