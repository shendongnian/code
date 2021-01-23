    class Program
    {
        static void Main()
        {
            var service = new MyService1();
            var result = service.SomeMethod(new SomeDataContract
            {
                Prop1 = "value 1"
            });
        }
    }
