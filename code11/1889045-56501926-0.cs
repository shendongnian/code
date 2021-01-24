    public interface IPlugin
    {
        string Name { get; }
        void DoStuff();
    }
    public static class PluginRegistry
    {
        private static readonly List<IPlugin> plugins = new List<IPlugin>();
        public static IEnumerable<IPlugin> GetPlugins() => plugins;
        public static void Register(IPlugin plugin) => plugins.Add(plugin);
    }
    // And then an example plugin implementation
    public class MyPlugin : IPlugin
    {
        public string Name => "My fancy plugin";
        public void DoStuff() => Console.WriteLine("My fancy plugin was called!");
        static MyPlugin()
        {
            // automatically register the plugin when the type is laoded
            PluginRegistry.Register(new MyPlugin());
        }
    }
