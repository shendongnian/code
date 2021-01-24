    public class Core : ICoreApplication
    {
        public void InitPlugins()
        {
            IPlugin somePlugin = ...; //retrieve via reflection
            somePlugin.Init(this);
        }
    }
