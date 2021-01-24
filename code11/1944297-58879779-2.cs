    public class Singleton : MonoBehaviour
    {
        private static Singleton instance = null;
    
        private Singleton()
        {
        }
    
        public static Singleton Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
