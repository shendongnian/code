    public class SampleData
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public Uri TargetUri { get; set; }
        public ICommand NavigateCommand { get; private set; }
        public SampleData()
        {
            NavigateCommand =
                new DelegateCommand(
                    () => NavigationService.Navigate(TargetUri);
        }
    }
