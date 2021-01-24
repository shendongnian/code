    public class YourViewModel
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(isBusy, value);
        }
        
        public YourViewModel()
        {
            StartDownload();
        }
    
        private void StartDownload()
        {
            IsBusy = true;
    
            Task.Run(async() => 
                {
                  // Your download starts here
                  // await it
                  // and when it came finished:
                  Device.BeginInvokeOnMainThread(() => IsBusy = false);
                }
        }
    }
