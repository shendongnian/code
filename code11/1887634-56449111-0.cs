    public class TestUsage
    {
        public int IncrementId<T>(T test) where T : Test
        {
            return 1 + test.GetId();
        }
    }
