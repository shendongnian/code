    class TestCase
    {
        public void Visit(Action<T> action, T val) 
        {
            action(val);
        }
        
    }
    var tc = new TestCase();
    uint some_val = 3;
    tc.Visit((Action) (val) => Console.WriteLine("Val " + val));
