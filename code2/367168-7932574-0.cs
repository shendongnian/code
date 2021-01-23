    class MyClass
    {
        static Dictionary<string, MethodInfo> cache = new ...
        public void InvokeByName(string name)
        {
            MethodInfo methodInfo = GetMethodInfoFromCache(name);
            methodInfo.Invoke(this, new object[] {});
        }
