    class GetSubscribedMethodsExample
    {
        public static void Execute()
        {
            var instance = new MyClass();
            instance.MyEvent += new EventHandler(MyHandler);
            instance.MyEvent += (s, e) => { };
            instance.GetSubscribedMethods()
                .Run(h => Console.WriteLine(h.Name));
        }
        static void MyHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
