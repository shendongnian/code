    class Foo
    {
        private string bar;
        public string Bar
        {
            get { return bar; }
            set
            {
                if(!IsValidBar(value))
                    throw new ArgumentException("bar is not valid.", "value");
                bar = value;
            }
        }
        private bool IsValidBar(string bar)
        {
            // blah blah
        }
    }
