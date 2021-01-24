    public class SomeClass
    {
        private readonly IHelpers<SomeClass> _helpers;
    
        public SomeClass(IHelpers<SomeClass> helpers)
        {
            _helpers = helpers;
        }
    }
