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
    
            Task.Run(ExceptionHandler(async() => 
                {
                  // Your download starts here
                  // await it
                  // and when it came finished:
                  Device.BeginInvokeOnMainThread(() => IsBusy = false);
                }));
        }
 
        private void ExceptionHandler(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch(Exception ex)
            {
                // Handle exceptions here
            }
        }
    }
