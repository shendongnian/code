    class Foo
    {
        private string bar;
        public string Bar
        {
            get { return bar; }
            set
            {
                if(!isValidBar(value))
                    throw new ArgumentException("bar is not valid.", "value");
                bar = value;
            }
        }
        private bool isValidBar(string bar)
        {
            // blah blah
        }
    }
