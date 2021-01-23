    public class SomeTypeWrapperFactory
    {
        public ISomeType<int> CreateWrapper(SomeType1 someType1)
        {
            return new SomeType1Wrapper(someType1);
        }
    
        public ISomeType<string> CreateWrapper(SomeType2 someType2)
        {
            return new SomeType2Wrapper(someType2);
        }
    }
    
    public class SomeType1Wrapper : ISomeType<int> { ... }
    public class SomeType2Wrapper : ISomeType<int> { ... }
