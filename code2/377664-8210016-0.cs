    public class MyService : IService
    {
        MyDll myDll = new MyDll();
        public void Method1()
        {
            
            myDll.Method1();
        }
        public string Method2(int someValue)
        {
        
            return myDll.Method2(someValue);
        }
        // and so on
    }
