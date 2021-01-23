    interface IMyInterface
    {
        string Get(string str = "Default");
    }
    
    class MyClass : IMyInterface
    {
        public string Get(string str)
        {
            return str;
        }
    }
