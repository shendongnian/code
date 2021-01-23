    public interface iExample
    {
        iExample Parse(string value);
    }
    class abc<T> where T : iExample, new()
    {
        private T foo;
        public string a
        {
            set
            {
                foo = (T)(new T().Parse(value));
            }
            get
            {
                return foo.ToString();
            }
        }
    }
