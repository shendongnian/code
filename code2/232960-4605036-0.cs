    public class MyBase
    {
            protected MyBase()
            {
                    this.VirtualMethod();
            }
     
            protected virtual void VirtualMethod()
            {
                    Console.WriteLine("VirtualMethod in MyBase");
            }
    }
     
    public class MyDerived : MyBase
    {
            private readonly string message = "Set by initializer";
     
            public MyDerived(string message)
            {
                    this.message = message;
            }
     
            protected override void VirtualMethod()
            {
                    Console.WriteLine(this.message);
            }
    }
