    public sealed class CustomPage : Page
    {
        private AppBar appbar;
        private InAppNotification note;
        public CustomPage()
        {
            this.DefaultStyleKey = typeof(CustomPage);
        }
        protected override void OnApplyTemplate()
        {
            appbar = GetTemplateChild("appbar") as AppBar;
            note = GetTemplateChild("note") as InAppNotification;
        }
        public void ShowNotification()
        {
            if (appbar != null)
                appbar.IsOpen = true;
            note?.Show();
        }
    }
