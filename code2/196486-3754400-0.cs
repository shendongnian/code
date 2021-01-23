    interface ISomething
    {
        string Test { get; }
    }
    class Something : ISomething
    {
        public string Test { get; private set; }
    }
