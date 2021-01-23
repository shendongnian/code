    public class JetPackTheme : Theme
    {
        private static Uri ThemeResourceUri = new Uri("/MyComponent;component/JetPackTheme.xaml", UriKind.Relative);
        public JetPackTheme() : base(ThemeResourceUri) { }
        public static bool GetIsApplicationTheme(Application app)
        {
            return GetApplicationThemeUri(app) == ThemeResourceUri;
        }
        public static void SetIsApplicationTheme(Application app, bool value)
        {
            SetApplicationThemeUri(app, ThemeResourceUri);
        }
    }
