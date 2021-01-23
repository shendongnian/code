    class Foo
    {
       public Foo(string bar) {
           if(!isValidBar(bar))
               throw new ArgumentException("bar is not valid.", "bar");
           this.Bar = bar;
       }
       public string Bar {get; set;}
        private bool isValidBar(string bar)
        {
            // blah blah
        }
    }
