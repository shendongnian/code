    class FooPlugin
    {
        static FooPlugin()
        {
            var bar = new Bar();
            Defaults = new DefaultValues()
                .Add(() => PluginFunction(42, 13))
                .Add(() => AnotherFunction(bar));
        }
        public static DefaultValues Defaults { get; private set; }
        // actual methods of the class
    }
