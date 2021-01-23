    [Plugin("A plugin function")]
    public static int PluginFunction(int a, int b)
    {
        return a + b;
    }
    public static object[] PluginFunctionDefaultArguments()
    {
        return new [] { 0, 0 };
    }
