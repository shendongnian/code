    public class FooBuilder
    {
        private readonly BooEnum _boo;
       
        public FooBuilder(BooEnum boo)
        {
            _boo = boo;
        }
        public FooClass Create()
        {
            return new FooClass()
            {
                BooEnum = _boo
            };
        }
    }
