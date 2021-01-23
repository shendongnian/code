    class Foo
    {
        private string _fooText;
        public Foo(string fooText)
        {
            _fooText = fooText;
        }
        public string Execute()
        {
            return string.Format("executed! with {0} !", _fooText);
        }
    }
    class Bar
    {
        public string BarContent { get; set; }
    }
