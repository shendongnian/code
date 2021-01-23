    interface ISomething
    {
        string Test { get; }
    }
    class Something : ISomething
    {
        public string Test { get; set; } // Note that set is public
    }
