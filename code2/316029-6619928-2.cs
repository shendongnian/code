    class Foo
    {
        private string _foo; 
        
        public Foo(string foo)
        {
            _foo = foo; 
        }
        public bool this[string foo]  // the indexer can be anything
        {
            get                  // the getter can work however the programmer wants
            {
                if (_foo == foo)       
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
