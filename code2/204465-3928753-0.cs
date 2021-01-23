    public class MyDuplicator
    {
        public static object GetNotClone(object X)
        {
            return Activator.CreateInstance(X.GetType());
        }
    }
