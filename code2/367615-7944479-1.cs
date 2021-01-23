    public class SomeClassWithDependency
    {
        public void TryDoSomething()
        {
            if (SomeType != null)
            {
                SomeType.DoSomething();
            }
        }
        [Inject, Optional]
        public ISomeType SomeType { get; set; }
    }
