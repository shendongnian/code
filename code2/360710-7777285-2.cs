    public class SomeClass
    {
        private class SomePrivateClass
        {
            public void DoSomething()
            {
            }
        }
        // Only SomeClass has access to SomePrivateClass,
        // and can access its public methods, properties etc
    }
