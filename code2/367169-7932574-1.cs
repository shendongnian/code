    class MyClass
    {
        static Dictionary<string, Action<MyClass>> cache = new ...
        public void InvokeByName(string name)
        {
            GetActionFromCache(name).Invoke(this);            
        }
