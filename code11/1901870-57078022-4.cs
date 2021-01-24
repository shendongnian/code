    public sealed class CustomPage : Page
    {
        public CustomPage()
        {
            this.DefaultStyleKey = typeof(CustomPage);
        }
        public void ShowNotification()
        {
            AppBar appBar = this.BottomAppBar;
            appBar.IsOpen = true;
            InAppNotification note = appBar.Content as InAppNotification;
            if(note != null)
                note.Show();
        }
    }
