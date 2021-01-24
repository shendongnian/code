    class Base
    {
        public string myString = "Hi";
        public Base(string str)
        {
            myString += str;
        }
        public Base(string str, Action<Base> runFirts)
        {
            runFirts?.Invoke(this);
            myString += str;
        }
    }
    class Main : Base
    {
        public Main() : base(
            "world",
            instance => { instance.myString = "Hello"; })
        {
        }
    }
