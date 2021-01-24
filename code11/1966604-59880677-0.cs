    public class A
    {
        private Messenger messenger = Messenger.Instance; //Messenger is singleton, means it is build to only have one instance
        public A()
        {
            messenger.Register<string>(this, "MyCode", MyMethod);
        }
        private void MyMethod(string str)
        {
            Console.WriteLine(str);
        }
    }
    public class B
    {
        private Messenger messenger = Messenger.Instance;
        public B()
        {
            messenger.Send<string>("Hello, World!", "MyCode");
        }
    }
