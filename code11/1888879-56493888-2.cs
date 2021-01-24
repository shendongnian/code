    public abstract class Plugin<T> where T : new()
    {
        private static readonly Lazy<T> val = new Lazy<T>(() => new T());
        public static T Instance { get { return val.Value; } }
        protected Plugin() { }
        public abstract string plugin_name();
    }
    public class Main : Plugin<Main> {
        public override string plugin_name() => "a test plugin";
    }
