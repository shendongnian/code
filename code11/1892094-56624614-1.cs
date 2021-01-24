    public class ShellViewModel:Screen, IHandle<SelectedItemChangedMessage<string>>
    {
            private IEventAggregator _eventAggregator;
            public ShellViewModel(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;
                _eventAggregator.Subscribe(this);
            }
    
            public void Handle(SelectedItemChangedMessage<string> message)
            {
                Debug.WriteLine($"Item Changed, current selection : {message}");
            }
    }
