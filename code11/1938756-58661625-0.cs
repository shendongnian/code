    public class StopWatchViewModel : INotifyPropertyChanged
    {
        public double PointerValue { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class StopWatchPage : BaseContentPage
    {
        private Timer timer;
        private readonly StopWatchViewModel model = new StopWatchViewModel();
        public StopWatchPage()
        {
            BindingContext = model;
            ...
            needlePointer.SetBinding(NeedlePointer.ValueProperty, 
              nameof(model.PointerValue));
            ...
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            model.PointerValue += 1;
        }
    }
