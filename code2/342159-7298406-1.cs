    public class PresonActions : IDisposable
    {
        ...
        public void Dispose()
        {
            ...
        }
    }
    public class Person
    {
        public static void Walk()
        {
            using(var actions = new PresonActions())
            {
                actions.Walk();
            }
        }
    }
