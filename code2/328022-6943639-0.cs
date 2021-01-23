    public class Singleton<T> where T : class, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("singleton needs to be initialised before use");
                }
                return instance;
            }
        }
        public static void Initialise(Action<T> initialisationAction)
        {
            lock(typeof(Singleton<T>))
            {
                if (instance != null)
                {
                    return;
                }
                instance = new T();
                initialisationAction(instance);
            }
        }
    }
