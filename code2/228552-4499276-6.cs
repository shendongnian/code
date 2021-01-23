    public abstract class Feed
    {
        public static T GetInstance<T>() where T:Feed, new()
        {
            T instance = new T();
            // TODO: Implement here other initializing behaviour
            return instance;
        }
    }
