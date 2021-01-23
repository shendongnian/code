    public abstract class ApplicationSettings<T>
    {
        public static T Load(string xml){ // Implementation }
        public static void Save (T obj) { // Implementation }
    }
    public class ApplicationParameters : ApplicationSettings<ApplicationParameters>
    {
    }
