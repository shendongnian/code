    namespace MyApp.Utilities
    {
        public static class Translations
        {
            public static string MyAwesomeString => GetTranslationClass.Singleton.GetMessage("MyAwesomeStringResource");
        }
    }
