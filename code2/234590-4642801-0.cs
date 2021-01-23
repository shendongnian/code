    public class TestClass
    {
        public void TestAction(Action<Items> action)
        {
            Items i = new Item() { Hello = "Hello World");
            action(i);
        }
    
        public TestClass()
        {
            TestAction(b => Console.WriteLine(b.Hello));
        }
    }
