    class Foo
    {
        public Foo(string bar) {
            if(!IsValidBar(bar))
                throw new ArgumentException("bar is not valid.", "bar");
            this.Bar = bar;
        }
        public string Bar {get; set;}
        private bool IsValidBar(string bar)
        {
            // blah blah
        }
    }
