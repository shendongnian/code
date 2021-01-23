        // Don't do this, the exception won't get thrown until the iterator is
        // iterated, which can be very far away from this method invocation
        public IEnumerable<string> Foo(Bar baz) 
        {
            if (baz == null)
                throw new ArgumentNullException();
             yield ...
        }
        // DO this
        public IEnumerable<string> Foo(Bar baz) 
        {
             return new BazIterator(baz);
        }
  
