    public class MyClass
    {
        public EventHandler OnSomeEvent;
        public void MyMethod(object state)
        {
            OnSomeEvent(null, null);
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(
                "main thread id: {0}", 
                Thread.CurrentThread.GetHashCode()
            );
            MyClass Foo = new MyClass();
            Foo.OnSomeEvent += new EventHandler(Foo_SomeEvent);
            ThreadPool.QueueUserWorkItem(Foo.MyMethod, null);
            Console.ReadKey();
        }
    
        static void Foo_SomeEvent(object sender, EventArgs e) 
        {
            Console.WriteLine(
                "Foo_SomeEvent thread id: {0}", 
                Thread.CurrentThread.GetHashCode()
            );
        }
    }
