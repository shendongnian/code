    [ModuleMessageHandler(typeof(SomeType))]
    class SomeClass
    {
        void SomeMethod()
        {
            ModuleMessageHandlerAttribute attribute = GetType()
                .GetCustomAttribute<ModuleMessageHandlerAttribute>();
            Type type = attribute.Type;
        }
    }
