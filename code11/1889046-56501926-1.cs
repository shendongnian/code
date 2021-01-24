    public static void Main()
    {
        foreach (var plugin in PluginRegistry.GetPlugins())
            plugin.DoStuff();
        // Output:
        // My fancy plugin was called!
    }
