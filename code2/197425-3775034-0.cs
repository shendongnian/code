    public static IEnumerable<CaptureType> ListPluginsWith<CaptureType>()
       where CaptureType : class
    {
        foreach (var plugin in Bot.AutoPlugins)
        {
            CaptureType plug = plugin.Interface as CaptureType;
            if (plug != null)
                yield return plug;
        }
    }
