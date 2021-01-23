    class MyException : BetterException
    {
        public MyException(string name)
        {
            Name = name;
        }
    
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
