    public abstract class Page
    {
        // Your normal Page base class things
    }
    public abstract class Page<T> : Page where T : Page<T>, new()
    {
        // Or whatever singleton pattern you want to implement
        public static readonly T Instance = new T();
    }
    public class HomePage : Page<HomePage>
    {
    }
