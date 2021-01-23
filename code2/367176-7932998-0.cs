    class MyClass
    {
        private static Dictionary<string, Action<MyClass>> methods;
    
        public void Method1()
        {
            // Do something.
        }
    
        public void Method2()
        {
            // Do something else.
        }
        static MyClass(){
           methods = new Dictionary<string, Action<MyClass>>();
           foreach(var method in typeof(MyClass).GetMethods(
                   BindingFlags.Public | BindingFlags.Instance)
           )
            {
                methods.Add(
                    method.Name,
                    Delegate.CreateDelegate(typeof(Action<MyClass>),method) 
                      as Action<MyClass>);
            }
        }
    }
