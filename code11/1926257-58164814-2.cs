    public class SplashMessageChangedEvent
    {
        public string Content { get; set; }
        public bool CloseDialog { get; set; } = false;
        public SplashMessageChangedEvent(string content)
        {
            Content = content;
        }
        public SplashMessageChangedEvent(bool closeDialog)
        {
            CloseDialog = closeDialog;
        }
    }
