    using System;
    
    public static class TestMethods
    {
        public static void Foo(int x)
        {
            Console.WriteLine("Foo " + x);
        }
    
        public static void Bar(int x)
        {
            Console.WriteLine("Bar " + x);
        }
    }
    
    public class DummyClass
    {
        private readonly Action<int> action;
        
        public DummyClass(Action<int> action)
        {
            this.action = action;
        }
        
        public void CallAction(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                action(i);
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            DummyClass d1 = new DummyClass(TestMethods.Foo);
            DummyClass d2 = new DummyClass(TestMethods.Bar);
            d1.CallAction(2, 4);
            d2.CallAction(3, 7);
        }
    }
