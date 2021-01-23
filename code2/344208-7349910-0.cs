    public class SomeViewModel : NotificationObject
    {
        public SomeViewModel()
        {
            DoFooCommand = new DelegateCommand(ExecuteFoo);
        }
        public DelegateCommand DoFooCommand { get; set; }
        private void ExecuteFoo()
        {
            //Use the EventAggregator to publish a common event
        }
    }
