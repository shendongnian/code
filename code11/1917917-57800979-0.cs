    public class HeaderViewModel : Observable, IDisposableAsync
    {
        public HeaderViewModel(IDateTimeProvider dateTimeProvider)
        {
            DateTimeProvider = dateTimeProvider;
            UpdateTimeData();
            var weakReference = new WeakReference(this);
            Task.Run(
                async () =>
                {
                    while(!((HeaderViewModel)weakReference.Target).IsDisposing)
                    {
                        ((HeaderViewModel)weakReference.Target).UpdateTimeData();
                        await Task.Delay(800);
                    }
                    ((HeaderViewModel)weakReference.Target).IsDisposed = true;
                });
        }
        public bool IsDisposed { get; set; }
        public IBrushStore BrushStore { get; }
        public IImageStore ImageStore { get; }
        public string TimeText
        {
            get => Get<string>();
            set => Set(value);
        }
        public string DateText
        {
            get => Get<string>();
            set => Set(value);
        }
        private IDateTimeProvider DateTimeProvider { get; }
        private bool IsDisposing { get; set; }
        public async Task Dispose()
        {
            IsDisposing = true;
            while(!IsDisposed)
            {
                await Task.Delay(50);
            }
        }
        private void UpdateTimeData()
        {
            TimeText = DateTimeProvider.Now.ToString("HH:mm:ss");
            DateText = DateTimeProvider.Now.ToString("dd.MM.yyyy");
        }
    }
