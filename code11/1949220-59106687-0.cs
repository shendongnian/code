    public static class TestAssertionExtensions
    {
        public static TestAssertions Should(this BaseTest instance)
        {
            return new TestAssertions(instance);
        }
    }
